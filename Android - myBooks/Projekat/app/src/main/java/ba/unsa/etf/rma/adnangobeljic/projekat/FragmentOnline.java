package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.res.Configuration;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.ResultReceiver;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.Spinner;
import android.widget.Toast;

import com.squareup.picasso.Picasso;

import java.util.ArrayList;


public class FragmentOnline extends Fragment implements DohvatiKnjige.IDohvatiKnjigeDone,DohvatiNajnovije.IDohvatiNajnovijeDone, BookshelfResultReceiver.Receiver  {
    int stanje;
    ArrayList<String> upiti = new ArrayList<String>();
    static ArrayList<Knjiga> knjigeSpinner = new ArrayList<Knjiga>();
    static String upitt = "";
    static ArrayList<String> lista = new ArrayList<String>();
    Spinner sRezultat;
    int spinnerKnjiga = -1;
    static int kategorijaa = -1;
    ArrayAdapter<String> adapterKategorija;
    ArrayAdapter<String> adapterKnjiga;

    int brojStringova = 1;




    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View v = inflater.inflate(R.layout.fragment_online, container, false);
        final ArrayList<String> kategorije = getArguments().getStringArrayList("Kategorije");
        final Spinner sKategorijaKnjige = v.findViewById(R.id.sKategorije);
        Button dPovratak = v.findViewById(R.id.dPovratak);
        Button dAdd = v.findViewById(R.id.dAdd);
        Button dRun = v.findViewById(R.id.dRun);
        final EditText tekstUpit = v.findViewById(R.id.tekstUpit);
        sRezultat = v.findViewById(R.id.sRezultat);
        tekstUpit.setText(upitt);



        tekstUpit.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                upitt=tekstUpit.getText().toString();

            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        /*final ArrayAdapter<String> adapterKnjiga;*/
        adapterKnjiga = new ArrayAdapter<String>(getContext(), android.R.layout.simple_spinner_item,lista);
        sRezultat.setAdapter(adapterKnjiga);


       /* final ArrayAdapter<String> adaptercic;*/
        adapterKategorija = new ArrayAdapter<String>(getContext(), android.R.layout.simple_spinner_item, ((KategorijeAkt) getActivity()).kategorije);
        sKategorijaKnjige.setAdapter(adapterKategorija);

        if (kategorijaa >= 0)
            sKategorijaKnjige.setSelection(kategorijaa);

        sKategorijaKnjige.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                kategorijaa = (int) sKategorijaKnjige.getSelectedItemId();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });

        sRezultat.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                spinnerKnjiga = (int)sRezultat.getSelectedItemId();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });


        dPovratak.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                upitt="";
                knjigeSpinner = new ArrayList<Knjiga>();
                lista = new ArrayList<String>();
                kategorijaa=-1;

                ((KategorijeAkt) getActivity()).editVrsta("ListeFragment");
                ((KategorijeAkt) getActivity()).pokreniListeFragment();
            }
        });

        dAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(knjigeSpinner.size()==0)
                {
                    Toast.makeText(getContext(),"Nije označena knjiga",Toast.LENGTH_LONG).show();
                }
                else {
                    Knjiga knjizica = knjigeSpinner.get(spinnerKnjiga);
                    knjizica.setKategorijaKnjige(sKategorijaKnjige.getSelectedItem().toString());
                    ArrayList<Knjiga> knjigeAct = ((KategorijeAkt) getActivity()).knjige;
                    boolean exists = false;
                    for (int i = 0; i < knjigeAct.size(); i++) {
                        if (knjigeAct.get(i).getId().equals(knjizica.getId())) {
                            Toast.makeText(getContext(), "Knjiga vec postoji", Toast.LENGTH_LONG).show();
                            exists = true;
                            break;
                        }
                    }
                    if (!exists) {
                       /* try {

                            ArrayList<Autor> autori = ((KategorijeAkt) getActivity()).autori;
                            for (int r = 0; r < knjizica.getAutori().size(); r++) {
                                boolean exist = false;
                                for (int d = 0; d < autori.size(); d++) {
                                    if (autori.get(d).getImeiPrezime().equals(knjizica.getAutori().get(r).getImeiPrezime())) {
                                        knjizica.changeNAuthor(r, autori.get(d));
                                        autori.get(d).dodajKnjigu(knjizica.getId());
                                        exist = true;
                                    }
                                }
                                if (!exist) autori.add(knjizica.getAutori().get(r));
                                ((KategorijeAkt) getActivity()).autori = autori;
                            }
                            knjigeAct.add(knjizica);
                            ((KategorijeAkt) getActivity()).knjige = knjigeAct;
                            Toast.makeText(getContext(), "Uspjesno dodana knjiga", Toast.LENGTH_LONG).show();
                        } catch (Exception e) {
                            Toast.makeText(getContext(), "Greska pri dodavanju", Toast.LENGTH_LONG).show();
                        }*/
                       try {
                           (new SQLKnjigaDBOpenHelper(getActivity())).dodajKnjigu(knjizica);
                           ((KategorijeAkt) getActivity()).knjige = (new SQLKnjigaDBOpenHelper(getActivity())).pokupiKnjige();
                           Toast.makeText(getContext(), "Uspjesno dodana knjiga", Toast.LENGTH_LONG).show();
                       }
                       catch(Exception e)
                       {
                           Toast.makeText(getContext(), "Greska pri dodavanju", Toast.LENGTH_LONG).show();
                       }

                    }
                }
            }
        });

        dRun.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(kategorije.size()==0)
                {
                    Toast.makeText(getContext(),"Prvo unesite kategorije",Toast.LENGTH_LONG).show();
                }
                else
                {
                    if(tekstUpit.getText().toString().length()==0)
                    {
                        Toast.makeText(getContext(),"Prvo unesite upit",Toast.LENGTH_LONG).show();
                    }
                    else
                    {
                        knjigeSpinner = new ArrayList<Knjiga>();
                        lista = new ArrayList<String>();
                        adapterKnjiga.clear();
                        OdrediStanje(tekstUpit.getText().toString());
                        brojStringova = upiti.size();
                        if (stanje == 1) {

                            new DohvatiKnjige((DohvatiKnjige.IDohvatiKnjigeDone) FragmentOnline.this).execute(tekstUpit.getText().toString());

                        }
                        if (stanje == 2) {

                            for (int i = 0; i < upiti.size(); i++) {
                                new DohvatiKnjige((DohvatiKnjige.IDohvatiKnjigeDone) FragmentOnline.this).execute(upiti.get(i).toString());
                            }


                        }
                        if (stanje == 3) {

                            new DohvatiNajnovije((DohvatiNajnovije.IDohvatiNajnovijeDone) FragmentOnline.this).execute(tekstUpit.getText().toString().substring(6));

                        }
                        if (stanje == 4) {
                            if(tekstUpit.getText().toString().toLowerCase().equals("korisnik:"))
                                Toast.makeText(getContext(),"Neispravan id",Toast.LENGTH_LONG).show();
                            else {
                                Intent intent = new Intent(Intent.ACTION_SYNC, null, getActivity(), BookshelfIntentService.class);
                                BookshelfResultReceiver mReceiver;
                                mReceiver = new BookshelfResultReceiver(new Handler());
                                mReceiver.setReceiver(FragmentOnline.this);
                                intent.putExtra("idKorisnika", tekstUpit.getText().toString().substring(9));
                                intent.putExtra("receiver", mReceiver);

                                getActivity().startService(intent);

                            }



                        }
                    }
                }
            }
        });
        return v;
    }

    public void OdrediStanje(String upit)
    {
        boolean tackaZarez = false;

        for(int i=0;i<upit.length();i++)
        {
            if(upit.charAt(i)==';')
            {
                tackaZarez=true;
                break;

            }
        }

        if(tackaZarez)
        {
            upiti = new ArrayList<String>();
            String[] upitt = upit.split(";");
            for(int p=0;p<upitt.length;p++)
            {
                upiti.add(upitt[p]);
            }
            stanje=2;
        }
        else
        {
            if(upit.length()>=6 && upit.charAt(0)=='a'   && upit.charAt(1)=='u'  && upit.charAt(2)=='t'  && upit.charAt(3)=='o'  && upit.charAt(4)=='r'  && upit.charAt(5)==':')
            {
                stanje=3;
            }
            else
            {
                if(upit.length()>=9 && upit.charAt(0)=='k'   && upit.charAt(1)=='o'  && upit.charAt(2)=='r'  && upit.charAt(3)=='i'  && upit.charAt(4)=='s'  && upit.charAt(5)=='n' && upit.charAt(6)=='i' && upit.charAt(7)=='k' && upit.charAt(8)==':')
                {
                    stanje=4;
                }
                else
                {
                    stanje=1;
                    upiti = new ArrayList<String>();
                    upiti.add(upit);
                }
            }






        }

    }

    @Override
    public void onDohvatiDone(ArrayList<Knjiga> knjige) {

        if(knjige.size()==0 && knjigeSpinner.size()==0 && brojStringova==1)
            Toast.makeText(getContext(),"Nema rezultata",Toast.LENGTH_LONG).show();
        for(int i=0;i<knjige.size();i++)
        {
            knjigeSpinner.add(knjige.get(i));
        }
        for(int i=0;i<knjige.size();i++) {
            lista.add(knjige.get(i).getNaziv());
            adapterKnjiga.add(knjige.get(i).getNaziv());
        }
        brojStringova--;
        if(brojStringova==0)
        {

            /*((KategorijeAkt)getActivity()).pokreniFragmentOnline();*/

        }



    }

    @Override
    public void onNajnovijeDone(ArrayList<Knjiga> knjige) {
        knjigeSpinner = new ArrayList<Knjiga>();
        lista = new ArrayList<String>();
        adapterKnjiga.clear();


        for(int i=0;i<knjige.size();i++)
        {
            knjigeSpinner.add(knjige.get(i));
        }
        for(int i=0;i<knjige.size();i++)
        {
            lista.add(knjige.get(i).getNaziv());
            adapterKnjiga.add(knjige.get(i).getNaziv());
        }








    }
    @Override
    public void onReceiveResult(int resultCode, Bundle resultData) {

        switch(resultCode)
        {
            case BookshelfIntentService.STATUS_START:
                break;
            case BookshelfIntentService.STATUS_FINISH:
                ArrayList<Knjiga> knjige = resultData.getParcelableArrayList("Knjige");
                knjigeSpinner = new ArrayList<Knjiga>();
                lista = new ArrayList<String>();
                adapterKnjiga.clear();

                for(int i=0;i<knjige.size();i++)
                {
                    knjigeSpinner.add(knjige.get(i));
                }
                for(int i=0;i<knjige.size();i++)
                {
                    lista.add(knjige.get(i).getNaziv());
                    adapterKnjiga.add(knjige.get(i).getNaziv());

                }



                break;
            case BookshelfIntentService.STATUS_ERROR:
                String error = resultData.getString(Intent.EXTRA_TEXT);
                Toast.makeText(getContext(),error,Toast.LENGTH_LONG).show();
                break;

        }
    }
    private void lockScreenOrientation() {

        getActivity().setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_NOSENSOR);
    }

    private void unlockScreenOrientation() {
        getActivity().setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_SENSOR);

    }
}
