package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.Manifest;
import android.annotation.TargetApi;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.media.Image;
import android.net.Uri;
import android.os.Build;
import android.os.ParcelFileDescriptor;
import android.support.annotation.NonNull;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.app.NotificationCompatSideChannelService;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Filter;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.Toast;
import static android.Manifest.permission.READ_CONTACTS;
import static android.Manifest.permission.READ_EXTERNAL_STORAGE;

import java.io.FileDescriptor;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.PrintWriter;
import java.lang.reflect.Array;
import java.net.URISyntaxException;
import java.util.ArrayList;
import java.util.List;




public class KategorijeAkt extends AppCompatActivity{
    static ArrayList<Knjiga> knjige = new ArrayList<Knjiga>();
    static ArrayList<Autor> autori = new ArrayList<Autor>();
    static ArrayList<String> kategorije = new ArrayList<String>();
    private static final int REQUEST_READ_CONTACTS = 0;
    private static final int REQUEST_READ_EXTERNAL_STORAGE= 1;

    public static boolean dozvola=false;


    boolean landscape;


    static String vrsta = "ListeFragment";

    public void editVrsta(String vrsta) {
        this.vrsta = vrsta;
    }

    public boolean lendskejp() {
        FrameLayout desno = (FrameLayout) findViewById(R.id.frame_desno);
        return desno != null;
    }

    public Bitmap getBitmapFromUri(Uri uri) throws IOException {
        ParcelFileDescriptor parcelFileDescriptor =
                getContentResolver().openFileDescriptor(uri, "r");
        FileDescriptor fileDescriptor = parcelFileDescriptor.getFileDescriptor();
        Bitmap image = BitmapFactory.decodeFileDescriptor(fileDescriptor);
        parcelFileDescriptor.close();
        return image;
    }


    public void pokreniListeFragment() {
        FrameLayout desno = (FrameLayout) findViewById(R.id.frame_desno);
        FrameLayout levo = (FrameLayout) findViewById(R.id.frame_lijevo);
        FrameLayout glavno = (FrameLayout) findViewById(R.id.frame_glavni);
        knjige = (new SQLKnjigaDBOpenHelper(this)).pokupiKnjige();
        autori = (new SQLKnjigaDBOpenHelper(this)).pokupiAutore();
        kategorije = (new SQLKnjigaDBOpenHelper(this)).pokupiKategorije();

        if (desno == null) {
            levo.setVisibility(View.VISIBLE);


            FragmentManager fmjam = getSupportFragmentManager();
            ListeFragment liste = new ListeFragment();
            Bundle argument = new Bundle();

            argument.putParcelableArrayList("Knjige", knjige);
            argument.putParcelableArrayList("Autori", autori);
            argument.putStringArrayList("Kategorije", kategorije);
            liste.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_lijevo, liste).commit();
        } else {
            levo.setVisibility(View.VISIBLE);
            desno.setVisibility(View.VISIBLE);
            glavno.setVisibility(View.GONE);

            FragmentManager fmjam = getSupportFragmentManager();
            ListeFragment liste = new ListeFragment();
            Bundle argument = new Bundle();
            argument.putParcelableArrayList("Knjige", knjige);
            argument.putParcelableArrayList("Autori", autori);
            argument.putStringArrayList("Kategorije", kategorije);
            liste.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_lijevo, liste).commit();
        }
    }

    public void pokreniDodavanjeKnjigeFragment() {
        FrameLayout desno = (FrameLayout) findViewById(R.id.frame_desno);
        FrameLayout levo = (FrameLayout) findViewById(R.id.frame_lijevo);
        FrameLayout glavno = (FrameLayout) findViewById(R.id.frame_glavni);
        knjige = (new SQLKnjigaDBOpenHelper(this)).pokupiKnjige();
        autori = (new SQLKnjigaDBOpenHelper(this)).pokupiAutore();
        kategorije = (new SQLKnjigaDBOpenHelper(this)).pokupiKategorije();

        if (desno == null) {
            levo.setVisibility(View.VISIBLE);


            FragmentManager fmjam = getSupportFragmentManager();
            DodavanjeKnjigeFragment liste = new DodavanjeKnjigeFragment();
            Bundle argument = new Bundle();
            argument.putParcelableArrayList("Autori", autori);
            argument.putStringArrayList("Kategorije", kategorije);
            liste.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_lijevo, liste).commit();
        } else {
            levo.setVisibility(View.GONE);
            desno.setVisibility(View.GONE);
            glavno.setVisibility(View.VISIBLE);

            FragmentManager fmjam = getSupportFragmentManager();
            DodavanjeKnjigeFragment liste = new DodavanjeKnjigeFragment();
            Bundle argument = new Bundle();
            argument.putParcelableArrayList("Autori", autori);
            argument.putStringArrayList("Kategorije", kategorije);
            liste.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_glavni, liste).commit();
        }
    }

    public void pokreniKnjigeFragment(int stanje, Autor autor, String kategorija) {
        FrameLayout desno = (FrameLayout) findViewById(R.id.frame_desno);
        FrameLayout levo = (FrameLayout) findViewById(R.id.frame_lijevo);
        FrameLayout glavno = (FrameLayout) findViewById(R.id.frame_glavni);
        knjige = (new SQLKnjigaDBOpenHelper(this)).pokupiKnjige();
        autori = (new SQLKnjigaDBOpenHelper(this)).pokupiAutore();
        kategorije = (new SQLKnjigaDBOpenHelper(this)).pokupiKategorije();

        if (desno == null) {
            levo.setVisibility(View.VISIBLE);


            FragmentManager fmjam = getSupportFragmentManager();
            KnjigeFragment liste = new KnjigeFragment();
            Bundle argument = new Bundle();
            argument.putParcelable("Autor", autor);
            argument.putString("Kategorija", kategorija);
            argument.putParcelableArrayList("Knjige", knjige);
            argument.putInt("Stanje", stanje);
            liste.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_lijevo, liste).commit();
        } else {
            levo.setVisibility(View.VISIBLE);
            desno.setVisibility(View.VISIBLE);
            glavno.setVisibility(View.GONE);

            FragmentManager fmjam = getSupportFragmentManager();
            KnjigeFragment liste = new KnjigeFragment();
            Bundle argument = new Bundle();
            argument.putParcelable("Autor", autor);
            argument.putString("Kategorija", kategorija);
            argument.putParcelableArrayList("Knjige", knjige);
            argument.putInt("Stanje", stanje);
            liste.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_desno, liste).commit();
        }
    }

    public void pokreniFragmentOnline() {
        FrameLayout desno = (FrameLayout) findViewById(R.id.frame_desno);
        FrameLayout levo = (FrameLayout) findViewById(R.id.frame_lijevo);
        FrameLayout glavno = (FrameLayout) findViewById(R.id.frame_glavni);
        knjige = (new SQLKnjigaDBOpenHelper(this)).pokupiKnjige();
        autori = (new SQLKnjigaDBOpenHelper(this)).pokupiAutore();
        kategorije = (new SQLKnjigaDBOpenHelper(this)).pokupiKategorije();

        if (desno == null) {
            levo.setVisibility(View.VISIBLE);


            FragmentManager fmjam = getSupportFragmentManager();
            FragmentOnline online = new FragmentOnline();
            Bundle argument = new Bundle();
            argument.putStringArrayList("Kategorije", kategorije);
            online.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_lijevo, online).commit();
        } else {
            levo.setVisibility(View.GONE);
            desno.setVisibility(View.GONE);
            glavno.setVisibility(View.VISIBLE);

            FragmentManager fmjam = getSupportFragmentManager();
            FragmentOnline online = new FragmentOnline();
            Bundle argument = new Bundle();
            argument.putStringArrayList("Kategorije", kategorije);
            online.setArguments(argument);
            fmjam.beginTransaction().replace(R.id.frame_glavni, online).commit();
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_kategorije_akt);

        if(!dozvola) ActivityCompat.requestPermissions(KategorijeAkt.this, new String[]{Manifest.permission.READ_EXTERNAL_STORAGE},REQUEST_READ_EXTERNAL_STORAGE);


        FrameLayout desni = (FrameLayout) findViewById(R.id.frame_desno);
        FrameLayout lijevi = (FrameLayout) findViewById(R.id.frame_lijevo);
        FrameLayout glavni = (FrameLayout) findViewById(R.id.frame_glavni);
        FragmentManager fmjam = getSupportFragmentManager();

        knjige=null;
        autori=null;
        kategorije=null;


        knjige = (new SQLKnjigaDBOpenHelper(this)).pokupiKnjige();
        while(knjige==null);
        autori = (new SQLKnjigaDBOpenHelper(this)).pokupiAutore();
        while(autori==null);
        kategorije = (new SQLKnjigaDBOpenHelper(this)).pokupiKategorije();
        while(kategorije==null);

        if (desni != null) {
            // Nalazi se u landscape modu
            // Landscape ListeFragment + KnjigeFragment


            landscape = true;
            if (vrsta.equals("ListaFragment")) {

                ListeFragment liste = new ListeFragment();
                Bundle argument = new Bundle();
                argument.putParcelableArrayList("Knjige", knjige);
                argument.putParcelableArrayList("Autori", autori);
                argument.putStringArrayList("Kategorije", kategorije);
                liste.setArguments(argument);
                fmjam.beginTransaction().replace(R.id.frame_lijevo, liste).commit();

                KnjigeFragment detalji = new KnjigeFragment();
                Bundle argumenti = new Bundle();
                argumenti.putParcelableArrayList("Knjige", knjige);
                argumenti.putInt("Stanje", 0);
                argumenti.putString("Kategorija", "");

                detalji.setArguments(argumenti);
                desni.setVisibility(View.VISIBLE);
                lijevi.setVisibility(View.VISIBLE);
                glavni.setVisibility(View.GONE);
                fmjam.beginTransaction().replace(R.id.frame_desno, detalji).commit();

            }

            if (vrsta.equals("DodavanjeKnjigeFragment")) {
                DodavanjeKnjigeFragment detalji = new DodavanjeKnjigeFragment();
                Bundle argumenti = new Bundle();
                argumenti.putStringArrayList("Kategorije", kategorije);
                argumenti.putParcelableArrayList("Autori", autori);
                detalji.setArguments(argumenti);
                desni.setVisibility(View.GONE);
                lijevi.setVisibility(View.GONE);
                glavni.setVisibility(View.VISIBLE);

                fmjam.beginTransaction().replace(R.id.frame_glavni, detalji).commit();
            }

            if (vrsta.equals("KnjigeFragment")) {
                vrsta = "ListeFragment";
                KnjigeFragment detalji = new KnjigeFragment();
                Bundle argumenti = new Bundle();
                argumenti.putParcelableArrayList("Knjige", knjige);
                argumenti.putInt("Stanje", 0);
                argumenti.putString("Kategorija", "");

                detalji.setArguments(argumenti);
                desni.setVisibility(View.VISIBLE);
                lijevi.setVisibility(View.VISIBLE);
                glavni.setVisibility(View.GONE);


                fmjam.beginTransaction().replace(R.id.frame_desno, detalji).commit();

                ListeFragment liste = new ListeFragment();
                Bundle argument = new Bundle();
                argument.putParcelableArrayList("Knjige", knjige);
                argument.putParcelableArrayList("Autori", autori);
                argument.putStringArrayList("Kategorije", kategorije);
                liste.setArguments(argument);
                fmjam.beginTransaction().replace(R.id.frame_lijevo, liste).commit();


            }
            if (vrsta.equals("FragmentOnline")) {
                editVrsta("FragmentOnline");
                FragmentOnline online = new FragmentOnline();
                Bundle argumenti = new Bundle();

                online.setArguments(argumenti);
                argumenti.putStringArrayList("Kategorije", kategorije);
                desni.setVisibility(View.GONE);
                lijevi.setVisibility(View.GONE);
                glavni.setVisibility(View.VISIBLE);

                fmjam.beginTransaction().replace(R.id.frame_glavni, online).commit();
            }
            if (vrsta.equals("FragmentPreporuci")) {

                FragmentPreporuci preporuci = new FragmentPreporuci();
                Bundle argumenti = new Bundle();
                preporuci.setArguments(argumenti);

                desni.setVisibility(View.GONE);
                lijevi.setVisibility(View.GONE);
                glavni.setVisibility(View.VISIBLE);
                fmjam.beginTransaction().replace(R.id.frame_glavni, preporuci).commit();


            }
        } else {

            if (vrsta.equals("KnjigeFragment")) {

                KnjigeFragment detalji = new KnjigeFragment();
                Bundle argumenti = new Bundle();
                argumenti.putParcelableArrayList("Knjige", knjige);
                argumenti.putInt("Stanje", 0);
                argumenti.putString("Kategorija", "");
                fmjam.beginTransaction().replace(R.id.frame_lijevo, detalji).commit();
            }

            if (vrsta.equals("DodavanjeKnjigeFragment")) {

                DodavanjeKnjigeFragment detalji = new DodavanjeKnjigeFragment();
                Bundle argumenti = new Bundle();
                argumenti.putStringArrayList("Kategorije", kategorije);
                argumenti.putParcelableArrayList("Autori", autori);
                detalji.setArguments(argumenti);
                fmjam.beginTransaction().replace(R.id.frame_lijevo, detalji).commit();


            }

            if (vrsta.equals("ListeFragment")) {

                ListeFragment liste = new ListeFragment();
                Bundle argument = new Bundle();
                argument.putParcelableArrayList("Knjige", knjige);
                argument.putParcelableArrayList("Autori", autori);
                argument.putStringArrayList("Kategorije", kategorije);
                liste.setArguments(argument);
                fmjam.beginTransaction().replace(R.id.frame_lijevo, liste).commit();


            }
            if (vrsta.equals("FragmentOnline")) {

                FragmentOnline online = new FragmentOnline();
                Bundle argumenti = new Bundle();
                argumenti.putStringArrayList("Kategorije", kategorije);
                online.setArguments(argumenti);
                fmjam.beginTransaction().replace(R.id.frame_lijevo, online).commit();


            }
            if (vrsta.equals("FragmentPreporuci")) {

                FragmentPreporuci preporuci = new FragmentPreporuci();
                Bundle argumenti = new Bundle();
                preporuci.setArguments(argumenti);

                fmjam.beginTransaction().replace(R.id.frame_lijevo, preporuci).commit();


            }


            mayRequestContacts();
            landscape = false;
        }
    }
    public boolean mayRequestContacts() {
        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.M) {
            return true;
        }
        if (checkSelfPermission(READ_CONTACTS) == PackageManager.PERMISSION_GRANTED) {
            return true;
        }


        if (shouldShowRequestPermissionRationale(READ_CONTACTS)) {
            Snackbar.make(findViewById(R.id.dPosalji), "Dobar brale", Snackbar.LENGTH_LONG)
                    .setAction(android.R.string.ok, new View.OnClickListener() {
                        @Override
                        @TargetApi(Build.VERSION_CODES.M)
                        public void onClick(View v) {
                            requestPermissions(new String[]{READ_CONTACTS}, REQUEST_READ_CONTACTS);
                        }
                    });
        } else {
            requestPermissions(new String[]{READ_CONTACTS}, REQUEST_READ_CONTACTS);
        }
        return false;
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions,
                                           @NonNull int[] grantResults) {
        if (requestCode == REQUEST_READ_CONTACTS) {
            if (grantResults.length == 1 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                // Permission granted , Access contacts here or do whatever you need.
            }
        }
        if (requestCode == REQUEST_READ_EXTERNAL_STORAGE) {

            if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                dozvola = true;
            }
            ActivityCompat.requestPermissions(KategorijeAkt.this, new String[]{Manifest.permission.READ_CONTACTS},REQUEST_READ_CONTACTS);

        }
    }


}


