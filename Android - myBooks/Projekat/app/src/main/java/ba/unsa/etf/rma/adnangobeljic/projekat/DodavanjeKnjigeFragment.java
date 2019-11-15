package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.media.Image;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.os.ParcelFileDescriptor;
import android.provider.MediaStore;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.Toast;

import com.squareup.picasso.Picasso;
import com.squareup.picasso.Target;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileDescriptor;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

/*149 162 177 152 149 162*/
public class DodavanjeKnjigeFragment extends Fragment {
    ArrayList<String> kategorije;
    ArrayList<Autor> autori;
    Knjiga knjiga = new Knjiga();
    Autor author =  null;
    static int random = 0;

    public static DodavanjeKnjigeFragment newInstance() {
        DodavanjeKnjigeFragment fragment = new DodavanjeKnjigeFragment();
        return fragment;
    }

    static String autor = "";
    static String imeknjiga = "";
    static Bitmap profilna = null;
    static int kategorija = -1;
    static boolean prvi = true;
    static Bitmap neutralni = null;



    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View v = inflater.inflate(R.layout.fragment_dodavanje_knjige, container, false);
        kategorije = getArguments().getStringArrayList("Kategorije");
        autori = getArguments().getParcelableArrayList("Autori");
        final Spinner sKategorijaKnjige = (Spinner) v.findViewById(R.id.sKategorijaKnjige);
        Button dNadjiSliku = (Button) v.findViewById((R.id.dNadjiSliku));
        Button dPonisti = (Button) v.findViewById(R.id.dPonisti);
        Button dUpisiKnjigu = (Button) v.findViewById(R.id.dUpisiKnjigu);
        final EditText imeAutora = (EditText) v.findViewById(R.id.imeAutora);
        final EditText nazivKnjige = (EditText) v.findViewById(R.id.nazivKnjige);
        final ArrayList<Knjiga> knjige = new ArrayList<Knjiga>();
        final ImageView slika = (ImageView) v.findViewById(R.id.naslovnaStr);
        if (prvi)
        {
            neutralni = ((BitmapDrawable) slika.getDrawable()).getBitmap();
            profilna = neutralni;
        }
        slika.setImageBitmap(profilna);
        imeAutora.setText(autor);
        nazivKnjige.setText(imeknjiga);
        if (kategorija >= 0)
            sKategorijaKnjige.setSelection(kategorija);




        kategorije = (new SQLKnjigaDBOpenHelper(getActivity())).pokupiKategorije();
        final ArrayAdapter<String> adaptercic;
        adaptercic = new ArrayAdapter<String>(getContext(), android.R.layout.simple_spinner_item, kategorije);
        sKategorijaKnjige.setAdapter(adaptercic);

        imeAutora.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                autor = imeAutora.getText().toString();
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        nazivKnjige.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i1, int i2) {

            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i1, int i2) {
                imeknjiga = nazivKnjige.getText().toString();
            }

            @Override
            public void afterTextChanged(Editable editable) {

            }
        });

        sKategorijaKnjige.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                kategorija = (int) sKategorijaKnjige.getSelectedItemId();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        });


        dPonisti.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                imeAutora.setText("");
                nazivKnjige.setText("");
                kategorija = -1;
                profilna = neutralni;
                ((KategorijeAkt) getActivity()).editVrsta("ListeFragment");
                ((KategorijeAkt) getActivity()).pokreniListeFragment();

            }
        });

        dNadjiSliku.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent();
                intent.setType("image/*");
                intent.setAction(Intent.ACTION_GET_CONTENT);
                if (intent.resolveActivity(getActivity().getPackageManager()) != null) {
                    startActivityForResult(Intent.createChooser(intent, "Odaberi sliku"), 1);
                }
            }

        });

        dUpisiKnjigu.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                if (kategorije.size() == 0)
                    Toast.makeText(getActivity(), "Prvo dodajte kategorije", Toast.LENGTH_LONG).show();
                else {
 /*
                    int a=1;

                    for(int i=0;i<autori.size() && a==1;i++)
                    {
                        for(int j=0;j<autori.get(i).getKnjige().size() && a==1;j++)
                        {

                            for(int k=0;k<knjige.size() && a==1 ;k++)
                            {
                                if(knjige.get(k).getId().equals(autori.get(i).getKnjige().get(j)))
                                {
                                    autori.get(i).dodajKnjigu(knjige.get(k).getId());
                                    author=autori.get(i);
                                    knjiga=knjige.get(k);
                                    a=-1;


                                }
                            }
                        }
                    }*/
                    profilna=((BitmapDrawable)slika.getDrawable()).getBitmap();


                    slika.buildDrawingCache();
                    Bitmap b=slika.getDrawingCache();
                    ByteArrayOutputStream stream=new ByteArrayOutputStream();
                    b.compress(Bitmap.CompressFormat.JPEG,100,stream);
                    String path= MediaStore.Images.Media.insertImage(getActivity().getContentResolver(),b,"Naziv",null);


                    {

                        author = new Autor(autor,nazivKnjige.getText().toString()+sKategorijaKnjige.getSelectedItem().toString()+ String.valueOf(random));
                        ArrayList<Autor> autori_knjige = new ArrayList<Autor>();
                        autori_knjige.add(author);
                        knjiga = new Knjiga(nazivKnjige.getText().toString()+sKategorijaKnjige.getSelectedItem().toString()+ String.valueOf(random), autori_knjige, nazivKnjige.getText().toString(), sKategorijaKnjige.getSelectedItem().toString(),path);
                        random++;

                    }

                    long a = (new SQLKnjigaDBOpenHelper(getActivity())).dodajKnjigu(knjiga);

                    ((KategorijeAkt) getActivity()).autori = (new SQLKnjigaDBOpenHelper(getActivity())).pokupiAutore();
                    ((KategorijeAkt) getActivity()).knjige = (new SQLKnjigaDBOpenHelper(getActivity())).pokupiKnjige();


                    profilna = neutralni;
                    imeAutora.setText("");
                    nazivKnjige.setText("");
                    kategorija = -1;

                    ((KategorijeAkt) getActivity()).editVrsta("ListeFragment");
                    if (((KategorijeAkt) getActivity()).lendskejp()) {
                        ((KategorijeAkt) getActivity()).pokreniListeFragment();
                        ((KategorijeAkt) getActivity()).pokreniKnjigeFragment(0, null, "");
                    } else {
                        ((KategorijeAkt) getActivity()).pokreniListeFragment();
                    }
                }


            }
        });
        prvi = false;

        return v;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {

        final ImageView slika = (ImageView) getView().findViewById(R.id.naslovnaStr);
        Uri odabranaSlika=data.getData();
        InputStream stream=null;
        try {
            stream=getActivity().getContentResolver().openInputStream(odabranaSlika);
        }
        catch(FileNotFoundException error) {
            error.printStackTrace();
        }
        Bitmap b= BitmapFactory.decodeStream(stream);
        profilna = b;
        slika.setImageBitmap(b);




    }

}













