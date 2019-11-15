package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;

import java.util.ArrayList;


public class KnjigeFragment extends Fragment/* implements  View.OnClickListener*/{

    ArrayList<Knjiga> knjige = new ArrayList<Knjiga>();
    CustomKnjigaAdapter adapter;
    ArrayList<Knjiga> knjigee = new ArrayList<Knjiga>();


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View v = inflater.inflate(R.layout.fragment_knjige, container, false);

        Button dPovratak = (Button)v.findViewById(R.id.dPovratak);
        Autor autor;
        ListView listaKnjiga = (ListView)v.findViewById(R.id.listaKnjiga);
        if(((KategorijeAkt)getActivity()).lendskejp())
            dPovratak.setVisibility(View.INVISIBLE);
        else
            dPovratak.setVisibility(View.VISIBLE);
        String kategorija;
        knjigee = new ArrayList<Knjiga>();


        if(getArguments()!=null) {
            autor = getArguments().getParcelable("Autor");
            int stanje = getArguments().getInt("Stanje");


            if (stanje == 0) {
                knjige = getArguments().getParcelableArrayList("Knjige");
                kategorija = getArguments().getString("Kategorija");
                /*

                for (int i = 0; i < knjige.size(); i++) {

                    if (knjige.get(i).getKategorijaKnjige().toLowerCase().contains(kategorija.toLowerCase())) {
                        knjigee.add(knjige.get(i));
                    }
                }*/

                knjigee = (new SQLKnjigaDBOpenHelper(getActivity())).knjigeKategorije((new SQLKnjigaDBOpenHelper(getActivity())).pokupiIDKategorije(kategorija));
                adapter = new CustomKnjigaAdapter(getActivity(), knjigee);
                listaKnjiga.setAdapter(adapter);
                adapter.notifyDataSetChanged();
            }

            if (stanje == 1) {
                knjige = getArguments().getParcelableArrayList("Knjige");
                autor = getArguments().getParcelable("Autor");
               /* if (autor != null) {

                    for (int i = 0; i < knjige.size(); i++) {

                        for (int j = 0; j < knjige.get(i).getAutori().size(); j++) {
                            if ((knjige.get(i).getAutori().get(j).getImeiPrezime().toString().toUpperCase()).contains(autor.getImeiPrezime().toString().toUpperCase())) {

                                knjigee.add(knjige.get(i));
                            }

                        }
                    }*/
                    knjigee = (new SQLKnjigaDBOpenHelper(getActivity())).knjigeAutora((new SQLKnjigaDBOpenHelper(getActivity())).pokupiAutorovID(autor));

                    adapter = new CustomKnjigaAdapter(getActivity(), knjigee);
                    listaKnjiga.setAdapter(adapter);
                    adapter.notifyDataSetChanged();
                }

        }
        dPovratak.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                ((KategorijeAkt)getActivity()).editVrsta("ListeFragment");
                ((KategorijeAkt)getActivity()).pokreniListeFragment();


            }
        });

        listaKnjiga.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                view.setBackgroundColor(getResources().getColor(R.color.colorLightBlue));
                knjigee.get(i).oznaciProcitanom();
                for(int t=0;t<knjige.size();t++) {
                    if (knjige.get(t).getNaziv().equals(knjigee.get(i).getNaziv())) {
                        knjige.get(t).oznaciProcitanom();
                        t = knjige.size();
                    }
                }
                String strSQL = "UPDATE " + SQLKnjigaDBOpenHelper.DATABASE_TABLE_KNJIGA + " SET " + SQLKnjigaDBOpenHelper.KNJIGA_PROCITAN + "= 1 WHERE " + SQLKnjigaDBOpenHelper.KNJIGA_IDWEBSERVIS + " = '"+ knjigee.get(i).getId()+ "';";
                (new SQLKnjigaDBOpenHelper(getActivity())).getWritableDatabase().execSQL(strSQL);

                ((KategorijeAkt)getActivity()).knjige= (new SQLKnjigaDBOpenHelper(getActivity())).pokupiKnjige();
            }
        });




        return v;
    }

/*
    @Override
    public void onClick(View view) {
        switch (view.getId()) {
            case R.id.eButton:
                ((KategorijeAkt)getActivity()).pokreniFragmentPreporuci();
                break;

        }
    }*/
}


