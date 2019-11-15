package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.net.Uri;
import android.os.Parcel;
import android.support.v4.app.INotificationSideChannel;
import android.util.Log;
import android.widget.Toast;

import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class SQLKnjigaDBOpenHelper extends SQLiteOpenHelper{



    public static final String DATABASE_NAME = "mojaBaza.db";


    public static final String DATABASE_TABLE_KATEGORIJA = "Kategorija";
    public static final String DATABASE_TABLE_KNJIGA = "Knjiga";
    public static final String DATABASE_TABLE_AUTOR = "Autor";
    public static final String DATABASE_TABLE_AUTORSTVO = "Autorstvo";
    public static final int DATABASE_VERSION = 5;

    public static final String KNJIGA_ID = "_id";
    public static final String KNJIGA_NAZIV = "naziv";
    public static final String KNJIGA_OPIS = "opis";
    public static final String KNJIGA_DATUM_OBJAVLJIVANJA ="datumObjavljivanja";
    public static final String KNJIGA_BROJ_STRANICA ="brojStranica";
    public static final String KNJIGA_IDWEBSERVIS ="idWebServis";
    public static final String KNJIGA_IDKATEGORIJA = "idkategorije";
    public static final String KNJIGA_SLIKA ="slika";
    public static final String KNJIGA_PROCITAN ="pregledana";

    public static final String AUTOR_ID = "_id";
    public static final String AUTOR_IMEIPREZIME = "ime";

    public static final String KATEGORIJA_ID = "_id";
    public static final String KATEGORIJA_NAZIV = "naziv";

    public static final String AUTORSTVO_ID = "_id";
    public static final String AUTORSTVO_IDAUTORA = "idautora";
    public static final String AUTORSTVO_IDKNJIGE= "idknjige";

    public static final String DATABASE_CREATE_KATEGORIJA = "create table " +
            DATABASE_TABLE_KATEGORIJA + " (" + KATEGORIJA_ID +
            " integer primary key autoincrement, " +
            KATEGORIJA_NAZIV + " text unique);";

    public static final String DATABASE_CREATE_KNJIGA = "create table " +
            DATABASE_TABLE_KNJIGA + " (" + KNJIGA_ID +
            " integer primary key autoincrement, " +
            KNJIGA_NAZIV + " text, " +
            KNJIGA_OPIS + " text, " +
            KNJIGA_DATUM_OBJAVLJIVANJA + " text, " +
            KNJIGA_BROJ_STRANICA + " integer, " +
            KNJIGA_IDWEBSERVIS + " text, " +
            KNJIGA_IDKATEGORIJA + " integer, " +
            KNJIGA_SLIKA + " text, " +
            KNJIGA_PROCITAN + " integer); ";

    public static final String DATABASE_CREATE_AUTOR = "create table " +
            DATABASE_TABLE_AUTOR + " (" + AUTOR_ID +
            " integer primary key autoincrement, " +
            AUTOR_IMEIPREZIME + " text);";

    public static final String DATABASE_CREATE_AUTORSTVO = "create table " +
            DATABASE_TABLE_AUTORSTVO + " (" + AUTORSTVO_ID +
            " integer primary key autoincrement, " +
            AUTORSTVO_IDAUTORA + " integer, " +
            AUTORSTVO_IDKNJIGE + " integer);";

    public Context mContext;

    public SQLKnjigaDBOpenHelper(Context context) {

        super(context, DATABASE_NAME, null, DATABASE_VERSION);
        mContext = context;
    }



    @Override
    public void onCreate(SQLiteDatabase sqLiteDatabase) {
        sqLiteDatabase.execSQL(DATABASE_CREATE_KNJIGA);
        sqLiteDatabase.execSQL(DATABASE_CREATE_AUTOR);
        sqLiteDatabase.execSQL(DATABASE_CREATE_KATEGORIJA);
        sqLiteDatabase.execSQL(DATABASE_CREATE_AUTORSTVO);

    }

    @Override
    public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1) {
        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + DATABASE_TABLE_KNJIGA + ";");
        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + DATABASE_TABLE_AUTOR + ";");
        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + DATABASE_TABLE_KATEGORIJA + ";");
        sqLiteDatabase.execSQL("DROP TABLE IF EXISTS " + DATABASE_TABLE_AUTORSTVO + ";");
        onCreate(sqLiteDatabase);
    }



    public synchronized long dodajKategoriju(String naziv)
    {
        ContentValues values = new ContentValues();
        values.put(SQLKnjigaDBOpenHelper.KATEGORIJA_NAZIV, naziv);
        long id;
        SQLiteDatabase db;

        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return -1;
        }


        try
        {

            id = db.insert(DATABASE_TABLE_KATEGORIJA, null, values);
        }
        catch(Exception e)
        {
              
            return -1;
        }
          
        return id;
    }

    public synchronized  long dodajKnjigu(Knjiga knjiga)
    {
        long id;
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return -1;
        }
        try {
            ContentValues values = new ContentValues();

            int pro = 0;
            if (knjiga.jelProcitana()) pro = 1;

            long idd = pokupiIDKategorije(knjiga.getKategorijaKnjige());
            if(idd==-1) {
                  
                return -1;
            }
            String slikica=null;

            if(knjiga.getPoster()=="" || knjiga.getPoster()==null)
                slikica=knjiga.getSlika().toString();
            else
            {
                slikica=knjiga.getPoster();
            }
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_NAZIV, knjiga.getNaziv());
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_OPIS, knjiga.getOpis());
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_DATUM_OBJAVLJIVANJA, knjiga.getDatumObjavljivanja());
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_BROJ_STRANICA, knjiga.getBrojStranica());
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_IDWEBSERVIS, knjiga.getId());
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_IDKATEGORIJA, idd);
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_SLIKA, slikica);
            values.put(SQLKnjigaDBOpenHelper.KNJIGA_PROCITAN, pro);

            id = db.insert(DATABASE_TABLE_KNJIGA, null, values);


            for(int t=0;t<knjiga.getAutori().size();t++)
            {

                ContentValues valuess = new ContentValues();

                valuess.put(SQLKnjigaDBOpenHelper.AUTORSTVO_IDAUTORA, pokupiAutorovID(knjiga.getAutori().get(t)));
                valuess.put(SQLKnjigaDBOpenHelper.AUTORSTVO_IDKNJIGE, id);

                db.insert(DATABASE_TABLE_AUTORSTVO, null, valuess);
            }
              
        }
        catch(Exception e)
        {
              

            e.printStackTrace();
            return -1;
        }

        return id;
    }

    public synchronized ArrayList<Knjiga> knjigeKategorije(long idKategorije)
    {
        String[] cols = new String[] {
                KNJIGA_ID,
                KNJIGA_NAZIV,
                KNJIGA_OPIS,
                KNJIGA_DATUM_OBJAVLJIVANJA,
                KNJIGA_BROJ_STRANICA,
                KNJIGA_IDWEBSERVIS,
                KNJIGA_IDKATEGORIJA,
                KNJIGA_SLIKA,
                KNJIGA_PROCITAN,
                };

        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return new ArrayList<Knjiga>();
        }

        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_KNJIGA,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }

        if(cs == null || !cs.moveToFirst()) {
              
            return new ArrayList<Knjiga>();
        }
        ArrayList<Knjiga> knjige = new ArrayList<Knjiga>();
        do {
            try {
                URL uerel;
                String ueri;
                String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_ID));
                String naziv = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_NAZIV));
                String opis = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_OPIS));
                String datumObjavljivanja = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_DATUM_OBJAVLJIVANJA));

                String help = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_SLIKA));
                if(help.toLowerCase().contains("www") || help.toLowerCase().contains("http") )
                {
                    uerel = new URL(help);
                    ueri = null;
                }
                else
                {
                    uerel = null;
                    ueri = help;

                }


                int brojStranica =  Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_BROJ_STRANICA)));
                String idWebServis = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDWEBSERVIS));
                int pro = Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_PROCITAN)));
                boolean procitan = pro!=0;
                Long aa = Long.parseLong(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDKATEGORIJA)));

                String kategorija = pokupiKategorijusaID(Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDKATEGORIJA))));


                if(aa!=idKategorije)
                {
                    continue;
                }


                ArrayList<Autor> autori = pokupiAutoreKnjige(Integer.parseInt(id));

                knjige.add(new Knjiga(idWebServis,naziv,autori,opis,datumObjavljivanja,uerel,brojStranica,procitan,ueri,kategorija));


            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());



          
        return knjige;
    }

    public synchronized ArrayList<Knjiga> knjigeAutora(long idAutora)
    {
        ArrayList<Knjiga> knjige = new ArrayList<Knjiga>();
        ArrayList<Long> imaih = new ArrayList<Long>();
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return new ArrayList<Knjiga>();
        }
        try {
            String[] cols = new String[]{AUTORSTVO_ID, AUTORSTVO_IDAUTORA, AUTORSTVO_IDKNJIGE};
            Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTORSTVO, cols, null, null, null, null, null, null);
            if (cs != null) {
                cs.moveToFirst();
            }

            if (cs == null || !cs.moveToFirst())
            {
                  
                return new ArrayList<Knjiga>();
            }

            do {
                try {

                    String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_ID));
                    long IDAutora = (long) Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDAUTORA)));
                    long IDKnjige = (long) Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDKNJIGE)));

                    if (IDAutora == idAutora) {
                        boolean ex = false;
                        for(int t=0;t<imaih.size();t++)
                        {
                            if(imaih.get(t)==IDKnjige)
                            {
                                ex = true;
                                break;
                            }
                        }
                        if(!ex)
                        {
                            imaih.add(IDKnjige);
                            knjige.add(pokupiKnjigusaID(IDKnjige));
                        }



                    } else continue;


                } catch (Exception e) {
                    e.printStackTrace();
                }
            } while (cs.moveToNext());
        }
        catch(Exception e)
        {

        }
          
        return knjige;

    }


























    public synchronized long pokupiIDKategorije(String nazivv)
    {
        String[] cols = new String[] {
                SQLKnjigaDBOpenHelper.KATEGORIJA_ID,
                SQLKnjigaDBOpenHelper.KATEGORIJA_NAZIV};
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return -1;
        }
        Cursor cs = db.query(true, DATABASE_TABLE_KATEGORIJA,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }

        do {
            try {
                long id = (long)Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KATEGORIJA_ID)));
                String naziv = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KATEGORIJA_NAZIV));
                if(naziv.toLowerCase().equals(nazivv.toLowerCase())) {
                    /*  */
                    return id;
                }

            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());
        /*  */
        return -1;


    }

    public synchronized long pokupiAutorovID(Autor author)
    {
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return -1;
        }
        try {
            String[] cols = new String[]{AUTOR_ID,AUTOR_IMEIPREZIME,};
            Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTOR, cols, null, null, null, null, null, null);
            if (cs != null) {
                cs.moveToFirst();
            }



            do {
                try {
                   String imeiPrezime = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTOR_IMEIPREZIME));
                   if(author.getImeiPrezime().equals(imeiPrezime))
                       return (long)Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTOR_ID)));




                } catch (Exception e) {
                    e.printStackTrace();
                }
            } while (cs.moveToNext());

            ContentValues valuesss = new ContentValues();
            valuesss.put(SQLKnjigaDBOpenHelper.AUTOR_IMEIPREZIME, author.getImeiPrezime());
            long as =  db.insert(DATABASE_TABLE_AUTOR, null, valuesss);
              
            return as;

        }
        catch (Exception e)
        {
              
           return -1;
        }
    }



    public synchronized Autor pokupiAutoraID(String idd)
    {
        String[] cols = new String[] {
                SQLKnjigaDBOpenHelper.AUTOR_ID,
                SQLKnjigaDBOpenHelper.AUTOR_IMEIPREZIME,
                };
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return null;
        }
        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTOR,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }

        if(cs == null || !cs.moveToFirst())
            return null;

        ArrayList<Autor> autori = new ArrayList<Autor>();
        do {
            try {
                String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTOR_ID));
                if(!id.equals(idd))
                    continue;
                String imeiPrezime = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTOR_IMEIPREZIME));

                ArrayList<String> knjigeID = new ArrayList<String>();


                try {
                    String[] colss = new String[]{AUTORSTVO_ID, AUTORSTVO_IDAUTORA, AUTORSTVO_IDKNJIGE};
                    Cursor csss = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTORSTVO, colss, null, null, null, null, null, null);
                    if (csss != null) {
                        csss.moveToFirst();
                    }

                    if (csss == null || !csss.moveToFirst())
                    {
                          
                        return new Autor(imeiPrezime,new ArrayList<String>());
                    }

                    do {
                        try {

                            String iddd = csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_ID));
                            long IDAutora = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDAUTORA)));
                            long IDKnjige = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDKNJIGE)));

                            if (String.valueOf(IDAutora).equals(idd)) {
                                knjigeID.add(pokupiKnjigusaID(IDKnjige).getId());


                            } else continue;


                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    } while (csss.moveToNext());
                }
                catch(Exception e)
                {

                }
                     

                   return new Autor(imeiPrezime,knjigeID);

            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());


          
        return null;



    }
    public synchronized ArrayList<Autor> pokupiAutoreKnjige(long IDdKnjige)
    {
        ArrayList<Autor> autori = new ArrayList<>();

        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return new ArrayList<Autor>();
        }
        String[] colss = new String[] {AUTORSTVO_ID, AUTORSTVO_IDAUTORA, AUTORSTVO_IDKNJIGE};
        Cursor csss = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTORSTVO,colss,null
                , null, null, null, null, null);
        if (csss != null) {
            csss.moveToFirst();
        }

        if(csss == null || !csss.moveToFirst()) {
              
            return new ArrayList<Autor>();
        }

        ArrayList<Long> IDAutoraMnozina = new ArrayList<>();

        do {
            try {

                String iddd = csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_ID));
                long IDdAutora = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDAUTORA)));
                long IDKnjige = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDKNJIGE)));

                if(IDdKnjige==IDKnjige) {
                    IDAutoraMnozina.add(IDdAutora);
                    continue;
                }

            } catch (Exception e) {
                e.printStackTrace();
            }
        } while (csss.moveToNext());

        for(int i=0;i<IDAutoraMnozina.size();i++)
        {
            Autor autorista = pokupiAutoraBezKnjiga(IDAutoraMnozina.get(i));
            autorista = dodajAutoruKnjige(autorista,IDAutoraMnozina.get(i));
            autori.add(autorista);
        }
          
        return autori;
    }


    public synchronized Autor dodajAutoruKnjige(Autor a,Long ID)
    {
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return a;
        }
        String[] colss = new String[] {AUTORSTVO_ID, AUTORSTVO_IDAUTORA, AUTORSTVO_IDKNJIGE};
        Cursor csss = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTORSTVO,colss,null
                , null, null, null, null, null);
        if (csss != null) {
            csss.moveToFirst();
        }

        if(csss == null || !csss.moveToFirst())
            return a;



        do {
            try {

                String iddd = csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_ID));
                long IDAutora = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDAUTORA)));
                long IDKnjige = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDKNJIGE)));

                if(IDAutora==ID) {
                    a.dodajKnjigu(pokupiWebIdKnjigePutemID(IDKnjige));
                    continue;
                }

            } catch (Exception e) {
                e.printStackTrace();
                  
                return a;
            }
        } while (csss.moveToNext());

          
        return a;

    }

    public synchronized Autor pokupiAutoraBezKnjiga(long IDAutora) {
        String[] cols = new String[]{SQLKnjigaDBOpenHelper.AUTOR_ID, SQLKnjigaDBOpenHelper.AUTOR_IMEIPREZIME,};
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return null;
        }
        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTOR, cols, null, null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }

        if (cs == null || !cs.moveToFirst())
        {
              
            return null;
        }


        do {
            try {
                Long iddd = Long.parseLong(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTOR_ID)));
                String imeiPrezime = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTOR_IMEIPREZIME));
                ArrayList<String> knjigice = new ArrayList<String>();
                if(iddd==IDAutora)
                {
                      
                    return new Autor(imeiPrezime,knjigice);
                }
            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());
          
        return null;


    }



    public synchronized String pokupiWebIdKnjigePutemID(long IDKnjige)
    {
        String[] cols = new String[] {
                KNJIGA_ID,
                KNJIGA_NAZIV,
                KNJIGA_OPIS,
                KNJIGA_DATUM_OBJAVLJIVANJA,
                KNJIGA_BROJ_STRANICA,
                KNJIGA_IDWEBSERVIS,
                KNJIGA_IDKATEGORIJA,
                KNJIGA_SLIKA,
                KNJIGA_PROCITAN,
        };

        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return null;
        }

        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_KNJIGA,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }

        if(cs == null || !cs.moveToFirst()) {
              
            return null;
        }

        do {
            try {

                String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_ID));
                String idWebServis = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDWEBSERVIS));
                if(Long.parseLong(id)==IDKnjige) {
                      
                    return idWebServis;
                }


            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());
          
        return null;
    }



    public synchronized Knjiga pokupiKnjigusaID(long IDKnjige)
    {
        String[] cols = new String[] {
                KNJIGA_ID,
                KNJIGA_NAZIV,
                KNJIGA_OPIS,
                KNJIGA_DATUM_OBJAVLJIVANJA,
                KNJIGA_BROJ_STRANICA,
                KNJIGA_IDWEBSERVIS,
                KNJIGA_IDKATEGORIJA,
                KNJIGA_SLIKA,
                KNJIGA_PROCITAN,
        };
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return null;
        }

        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_KNJIGA,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }

        if(cs == null || !cs.moveToFirst()) {
              
            return null;
        }


        do {
            try {
                URL uerel;
                String ueri;
                String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_ID));
                String naziv = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_NAZIV));
                String opis = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_OPIS));
                String datumObjavljivanja = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_DATUM_OBJAVLJIVANJA));

                if(!id.equals(String.valueOf(IDKnjige)))
                    continue;
                String help = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_SLIKA));
                if(help.toLowerCase().contains("www") || help.toLowerCase().contains("http") )
                {
                    uerel = new URL(help);
                    ueri = null;

                }
                else
                {
                    uerel = null;
                    ueri = help;

                }


                int brojStranica =  Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_BROJ_STRANICA)));
                String idWebServis = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDWEBSERVIS));
                int pro = Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_PROCITAN)));
                boolean procitan = pro!=0;

                String kategorija = pokupiKategorijusaID(Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDKATEGORIJA))));

                ArrayList<Autor> autori = pokupiAutoreKnjige(Integer.parseInt(id));
                  
                return new Knjiga(idWebServis,naziv,autori,opis,datumObjavljivanja,uerel,brojStranica,procitan,ueri,kategorija);


            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());
          
        return null;
    }

    public synchronized ArrayList<String> pokupiKategorije()
    {
        SQLiteDatabase db;

        ArrayList<String> kategorije = new ArrayList<String>();
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();

            return kategorije;
        }
        String[] cols = new String[] {
                SQLKnjigaDBOpenHelper.KATEGORIJA_ID,
                SQLKnjigaDBOpenHelper.KATEGORIJA_NAZIV};
        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_KATEGORIJA,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }
        if(cs==null) {
            db.close();
            return kategorije;
        }


        do {
            try {
                String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KATEGORIJA_ID));
                String naziv = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KATEGORIJA_NAZIV));

                kategorije.add(naziv);

            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());
        db.close();
    return kategorije;
    }

    public synchronized ArrayList<Autor> pokupiAutore()
    {
        ArrayList<Autor> authors = new  ArrayList<Autor>();
        ArrayList<String> idjvideos = new ArrayList<String>();
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return authors;
        }
        try {
            String[] colss = new String[]{AUTORSTVO_ID, AUTORSTVO_IDAUTORA, AUTORSTVO_IDKNJIGE};
            Cursor csss = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_AUTORSTVO, colss, null, null, null, null, null, null);
            if (csss != null) {
                csss.moveToFirst();
            }

            if (csss == null || !csss.moveToFirst())
            {
                db.close();
                return authors;
            }

            do {
                try {

                    String iddd = csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_ID));
                    long IDAutora = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDAUTORA)));
                    long IDKnjige = (long) Integer.parseInt(csss.getString(csss.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.AUTORSTVO_IDKNJIGE)));

                    boolean exist = false;

                    for(int t=0;t<idjvideos.size();t++)
                    {
                        if(Long.parseLong(idjvideos.get(t))==IDAutora)
                        {
                            exist=true;
                            ArrayList<String> knjh;
                            pokupiKnjigusaID(IDKnjige).getId();
                            /*knjh = authors.get(t).getKnjige();
                            knjh.add(pokupiKnjigusaID(IDKnjige).getId());
                            authors.set(t, new Autor(authors.get(t).getImeiPrezime(),knjh));*/
                            break;
                        }

                    }
                    if(!exist)
                    {
                        idjvideos.add(String.valueOf(IDAutora));
                        authors.add(pokupiAutoraID(String.valueOf(IDAutora)));
                    }





                } catch (Exception e) {
                    e.printStackTrace();
                }
            } while (csss.moveToNext());
        }
        catch(Exception e)
        {

        }
        db.close();
        return authors;
    }


    public synchronized ArrayList<Knjiga> pokupiKnjige()
    {
        ArrayList<Knjiga> knjigeee = new ArrayList<Knjiga>();
        String[] cols = new String[] {
                KNJIGA_ID,
                KNJIGA_NAZIV,
                KNJIGA_OPIS,
                KNJIGA_DATUM_OBJAVLJIVANJA,
                KNJIGA_BROJ_STRANICA,
                KNJIGA_IDWEBSERVIS,
                KNJIGA_IDKATEGORIJA,
                KNJIGA_SLIKA,
                KNJIGA_PROCITAN,
        };
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return knjigeee;
        }
        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_KNJIGA,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }

        if(cs == null || !cs.moveToFirst())
        {
            db.close();
            return knjigeee;
        }


        do {
            try {
                URL uerel;
                String ueri;
                String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_ID));
                String naziv = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_NAZIV));
                String opis = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_OPIS));
                String datumObjavljivanja = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_DATUM_OBJAVLJIVANJA));

                String help = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_SLIKA));
                if(help.toLowerCase().contains("www") || help.toLowerCase().contains("http") )
                {
                    uerel = new URL(help);
                    ueri = null;
                }
                else
                {
                    uerel = null;
                    ueri = help;
                }


                int brojStranica =  Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_BROJ_STRANICA)));
                String idWebServis = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDWEBSERVIS));
                int pro = Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_PROCITAN)));
                boolean procitan = pro!=0;

                String kategorija = pokupiKategorijusaID(Integer.parseInt(cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KNJIGA_IDKATEGORIJA))));

                ArrayList<Autor> autori = pokupiAutoreKnjige((long)Integer.parseInt(id));

                knjigeee.add(new Knjiga(idWebServis,naziv,autori,opis,datumObjavljivanja,uerel,brojStranica,procitan,ueri,kategorija));


            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());
        db.close();
        return knjigeee;
    }

    public synchronized String pokupiKategorijusaID(long ajdi)
    {

        String[] cols = new String[] {
                SQLKnjigaDBOpenHelper.KATEGORIJA_ID,
                SQLKnjigaDBOpenHelper.KATEGORIJA_NAZIV};
        SQLiteDatabase db;
        try {
            db = getWritableDatabase();
        } catch (Exception s) {
            Toast.makeText(mContext,"Neuspjesno otvaranje baze. Pokusajte ponovo. ",Toast.LENGTH_LONG).show();
            return null;
        }
        Cursor cs = db.query(true, SQLKnjigaDBOpenHelper.DATABASE_TABLE_KATEGORIJA,cols,null
                , null, null, null, null, null);
        if (cs != null) {
            cs.moveToFirst();
        }


        do {
            try {
                String id = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KATEGORIJA_ID));
                String naziv = cs.getString(cs.getColumnIndexOrThrow(SQLKnjigaDBOpenHelper.KATEGORIJA_NAZIV));
                if(Integer.parseInt(id)==ajdi)
                {
                      
                    return naziv;
                }

            } catch (Exception e) {
                e.printStackTrace();
            }
        } while(cs.moveToNext());

          
        return null;
    }


}
