package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.app.Activity;
import android.content.Context;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.constraint.ConstraintLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.NotificationCompatSideChannelService;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Adapter;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
/*

    <ImageView
        android:id="@+id/eeNaslovna"
        android:layout_width="100dp"
        android:layout_height="122dp"
        android:layout_alignParentStart="true"
        android:layout_alignParentTop="true"
        android:layout_marginStart="10dp"
        android:layout_marginTop="18dp"
        app:srcCompat="@drawable/grof_monte_cristo" />
    <LinearLayout
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:layout_toEndOf="@id/eeNaslovna"
        android:layout_marginStart="10dp"
        android:layout_alignBottom="@id/eeNaslovna"
        android:layout_alignTop="@id/eeNaslovna"
        android:layout_marginEnd="10dp"
        android:orientation="vertical"
        >
 */


public class ListeFragment extends Fragment {
    ArrayList<Knjiga> knjige = new ArrayList<Knjiga>();
    ArrayList<Autor> autori = new ArrayList<Autor>();
    ArrayList<String> kategorije = new ArrayList<String>();
    int stanje = 0; // -1 pocetno stanje , 0 lista kategorija , 1 lista autora

    ArrayAdapter<String> adapter1;
    CustomAutorAdapter adapter2;


    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);

        Button dDodajKnjigu = (Button) getView().findViewById(R.id.dDodajKnjigu);
        dDodajKnjigu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                ((KategorijeAkt) getActivity()).editVrsta("DodavanjeKnjigeFragment");
                ((KategorijeAkt) getActivity()).pokreniDodavanjeKnjigeFragment();

            }
        });


    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v = inflater.inflate(R.layout.fragment_liste, container, false);


       /* kategorije = getArguments().getStringArrayList("Kategorije");
        autori = getArguments().getParcelableArrayList("Autori");
        knjige = getArguments().getParcelableArrayList("Knjige");*/
        kategorije = ((KategorijeAkt)getActivity()).kategorije;
        autori =((KategorijeAkt)getActivity()).autori;
        knjige =((KategorijeAkt)getActivity()).knjige;


        if(knjige==null)
            knjige= new ArrayList<Knjiga>();
        stanje = 0;



        Button dKategorije = (Button) v.findViewById(R.id.dKategorije);
        Button dAutori = (Button) v.findViewById(R.id.dAutori);
        final EditText tekstPretraga = (EditText) v.findViewById(R.id.tekstPretraga);
        final Button dPretraga = (Button) v.findViewById(R.id.dPretraga);
        final Button dDodajKategoriju = (Button) v.findViewById(R.id.dDodajKategoriju);

        final ListView listaKategorija = (ListView) v.findViewById(R.id.listaKategorija);
        final ConstraintLayout drugiLay = (ConstraintLayout) v.findViewById(R.id.drugiLay);
        final Button dDodajOnline = (Button) v.findViewById(R.id.dDodajOnline);

        dDodajKategoriju.setEnabled(false);



        adapter1 = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, kategorije);
        listaKategorija.setAdapter(adapter1);

        dKategorije.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                ArrayAdapter<String> adapter1 = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, kategorije);
                listaKategorija.setAdapter(adapter1);
                tekstPretraga.setVisibility(View.VISIBLE);
                dPretraga.setVisibility(View.VISIBLE);
                dDodajKategoriju.setVisibility(View.VISIBLE);
                drugiLay.setVisibility(View.VISIBLE);
                stanje = 0;
            }
        });

        dAutori.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                tekstPretraga.setVisibility(View.GONE);
                dPretraga.setVisibility(View.GONE);
                dDodajKategoriju.setVisibility(View.GONE);
                drugiLay.setVisibility(View.GONE);


              /*  listaKategorija.setAdapter(null);*/


                adapter2 = new CustomAutorAdapter(getActivity(), autori);
                listaKategorija.setAdapter(adapter2);
                stanje = 1;

            }
        });

        tekstPretraga.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                dDodajKategoriju.setEnabled(false);
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        dPretraga.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (stanje != 0)
                    Toast.makeText(getActivity(), "Greska", Toast.LENGTH_LONG).show();
                else {
                    final String tekst = tekstPretraga.getText().toString();
                    adapter1 = (ArrayAdapter<String>) listaKategorija.getAdapter();
                    adapter1.getFilter().filter(tekst);
                    adapter1.notifyDataSetChanged();

                    int count = adapter1.getCount();

                    for (int t = 0; t < count; t++) {
                        if (adapter1.getItem(t).toUpperCase().contains(tekst.toUpperCase())) {
                            dDodajKategoriju.setEnabled(false);
                            return;
                        }
                    }
                    if (!tekst.equals(""))
                        dDodajKategoriju.setEnabled(true);

                }


            }
        });

        dDodajKategoriju.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ArrayAdapter<String> adapter = (ArrayAdapter<String>) listaKategorija.getAdapter();
                String tekst = tekstPretraga.getText().toString();

                (new SQLKnjigaDBOpenHelper(getActivity())).dodajKategoriju(tekst);
                kategorije = (new SQLKnjigaDBOpenHelper(getActivity())).pokupiKategorije();

                ArrayAdapter<String> adapter2 = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, kategorije);
                listaKategorija.setAdapter(adapter2);


/*
                kategorije.add(tekst);
                adapter.add(tekst);
                listaKategorija.setAdapter(adapter);*/
                dDodajKategoriju.setEnabled(false);
                tekstPretraga.setText("");



            }
        });


        listaKategorija.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {

                if(((KategorijeAkt)getActivity()).landscape==false)
                ((KategorijeAkt) getActivity()).editVrsta("KnjigeFragment");

                boolean exists = false;

                for (int t = 0; t < knjige.size(); t++) {
                    if (knjige.get(t).getKategorijaKnjige().equals(kategorije.get(t))) {
                        exists = true;
                        break;
                    }
                }

                if (stanje == 0)
                    ((KategorijeAkt) getActivity()).pokreniKnjigeFragment(stanje, null, kategorije.get(i));
                else {
                    if (exists)
                    {
                        ((KategorijeAkt) getActivity()).pokreniKnjigeFragment(stanje, autori.get(i), null);
                    }
                    else
                    {
                        ((KategorijeAkt) getActivity()).pokreniKnjigeFragment(stanje, null, kategorije.get(i));
                    }


                }
            }
        });

        dDodajOnline.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ((KategorijeAkt) getActivity()).editVrsta("FragmentOnline");
                ((KategorijeAkt) getActivity()).pokreniFragmentOnline();

            }
        });


        return v;
    }
}
