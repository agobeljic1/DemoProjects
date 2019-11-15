package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.Manifest;
import android.content.ContentResolver;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.Image;
import android.os.Build;
import android.provider.ContactsContract;
import android.provider.MediaStore;
import android.support.v4.app.Fragment;
import android.content.Context;
import android.net.Uri;
import android.os.Bundle;

import android.text.method.ScrollingMovementMethod;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.squareup.picasso.Picasso;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;


public class FragmentPreporuci extends Fragment {
    static Knjiga book;
    ArrayList<String> mailAdresses = new ArrayList<String>();
    ArrayList<String> names = new ArrayList<String>();
    Spinner sKontakti;
    ArrayAdapter<String> adaptercic;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View v =  inflater.inflate(R.layout.fragment_preporuci, container, false);
        if(book==null)
        book = (Knjiga)getArguments().getParcelable("Knjiga");
        ImageView eeNaslovna = (ImageView)v.findViewById(R.id.eeNaslovna);
        TextView eeNaziv = (TextView)v.findViewById(R.id.eeNaziv);
        TextView eeAutor = (TextView)v.findViewById(R.id.eeAutor);
        TextView eeDatumObjavljivanja = (TextView)v.findViewById(R.id.eeDatumObjavljivanja);
        TextView eeBrojStranica = (TextView)v.findViewById(R.id.eeBrojStranica);
        TextView eeOpis = (TextView)v.findViewById(R.id.eeOpis);
        sKontakti = (Spinner)v.findViewById(R.id.sKontakti);
        Button dPosalji = (Button)v.findViewById(R.id.dPosalji);
        eeOpis.setMovementMethod(new ScrollingMovementMethod());
        if(((KategorijeAkt)getActivity()).landscape)
        eeOpis.setMaxLines(2);
        else
            eeOpis.setMaxLines(10);


        if(book.getPoster()==null)
        {
            if(book.getSlika()!=null)
                Picasso.get().load(book.getSlika().toString()).into(eeNaslovna);
        }
        else
        {
            Bitmap b= null;
            Uri uri = Uri.parse(book.getPoster());
            try {
                b = MediaStore.Images.Media.getBitmap(getActivity().getContentResolver(),uri);
            } catch (IOException e) {
                e.printStackTrace();
            }

            eeNaslovna.setImageBitmap(b);

        }


        eeNaziv.setText("Naziv: " + book.getNaziv());
        String authors = "";
        if(book.getAutori().size()!=0)
            authors += book.getAutori().get(0).getImeiPrezime();
        for(int i=1;i<book.getAutori().size();i++)
            authors += ", " + book.getAutori().get(i).getImeiPrezime();
        eeAutor.setText("Autori: " + authors);
        eeDatumObjavljivanja.setText("Datum objavljivanja: " + book.getDatumObjavljivanja());
        if(book.getBrojStranica()==0)
            eeBrojStranica.setText("Broj stranica: ");
        else
        eeBrojStranica.setText("Broj stranica: " + String.valueOf(book.getBrojStranica()));
        eeOpis.setText("Opis: " + book.getOpis());


        if (!  ((KategorijeAkt)getActivity()).mayRequestContacts()) {
            Toast.makeText(getContext(),"Nema kontakata",Toast.LENGTH_LONG).show();
            ((KategorijeAkt)getActivity()).pokreniListeFragment();
        }
        else
        {
            PribaviKontakte();
            // This Build is < 6 , you can Access contacts here.
        }












        dPosalji.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                PosaljiEmail();

                book=null;
                ((KategorijeAkt)getActivity()).pokreniListeFragment();

            }
        });
        return v;
    }

    public void PribaviKontakte()
    {
        names = new ArrayList<String>();
        mailAdresses = new ArrayList<String>();


        ContentResolver contentResolver = getActivity().getContentResolver();
        Cursor kursor = contentResolver.query(ContactsContract.Contacts.CONTENT_URI,null,null,null,ContactsContract.Contacts.DISPLAY_NAME);
        if(kursor!=null && kursor.getCount() > 0)
        {
            while(kursor.moveToNext())
            {
                String id = kursor.getString(kursor.getColumnIndex(ContactsContract.Contacts._ID));
                Cursor emailCursor = contentResolver.query(ContactsContract.CommonDataKinds.Email.CONTENT_URI,null,ContactsContract.CommonDataKinds.Email.CONTACT_ID + " = ?",new String[]{id},null);
                while(emailCursor.moveToNext())
                {
                    names.add(kursor.getString(kursor.getColumnIndex(ContactsContract.Contacts.DISPLAY_NAME)));
                    mailAdresses.add(emailCursor.getString(emailCursor.getColumnIndex(ContactsContract.CommonDataKinds.Email.DATA)));

                }
                emailCursor.close();
            }
            kursor.close();

        }
        adaptercic = new ArrayAdapter<String>(getContext(), android.R.layout.simple_spinner_item, mailAdresses);
        sKontakti.setAdapter(adaptercic);
    }

    public void PosaljiEmail()
    {
        if(mailAdresses.size()==0)
        {
            Toast.makeText(getContext(),"Nema kontakata",Toast.LENGTH_LONG).show();
            return;
        }
        Log.i("Send email", "hhjhjhjuyhj");
        String[] TO = {mailAdresses.get((int)sKontakti.getSelectedItemId())};
      /*  String[] CC = {""};*/
        Intent emailIntent = new Intent(Intent.ACTION_SEND);
        emailIntent.setData(Uri.parse("mailto:"));
        emailIntent.setType("message/rfc822");
        emailIntent.putExtra(Intent.EXTRA_EMAIL, TO);
     /*   emailIntent.putExtra(Intent.EXTRA_CC, CC);*/
        emailIntent.putExtra(Intent.EXTRA_SUBJECT, "RMA");
        String authors = "";
        if(book.getAutori().size()!=0)
            authors+=book.getAutori().get(0).getImeiPrezime();
        for(int i=1;i<book.getAutori().size();i++)
        {
            authors+=", " + book.getAutori().get(i).getImeiPrezime();
        }
        emailIntent.putExtra(Intent.EXTRA_TEXT, "Zdravo " + names.get((int)sKontakti.getSelectedItemId()) + ",\nPročitaj knjigu " + book.getNaziv() + " od " + authors + "!");
        try {
            startActivity(Intent.createChooser(emailIntent, "Send mail..."));

            Log.i("Finished sending email", "lol");
        }
        catch (android.content.ActivityNotFoundException ex) {
            Toast.makeText(getContext(), "There is no email client installed.",
                    Toast.LENGTH_SHORT).show();
        }

    }

}
