package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.app.Activity;
import android.app.Application;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.BitmapDrawable;
import android.net.Uri;
import android.os.Bundle;
import android.provider.MediaStore;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.Fragment;
import android.support.v4.app.NotificationCompatSideChannelService;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.squareup.picasso.Picasso;

import java.io.IOException;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by PC on 3/28/2018.
 */

public class CustomKnjigaAdapter extends BaseAdapter implements Filterable{

    private Context mContext;
    private List<Knjiga> mKnjigaList;
    private List<Knjiga> KnjigaList;
    private CustomFilter cs;







    public CustomKnjigaAdapter(Context mContext, List<Knjiga> mKnjigaList) {
        this.mContext = mContext;
        this.mKnjigaList = mKnjigaList;
        this.KnjigaList = mKnjigaList;


    }




    @Override
    public int getCount() {
        return mKnjigaList.size();
    }

    @Override
    public Knjiga getItem(int position) {
        return mKnjigaList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(final int position, View view, ViewGroup viewGroup) {

        View v = view.inflate(mContext,R.layout.element_lista_knjiga,null);
        TextView NazivKnjiga = (TextView)v.findViewById(R.id.eNaziv);
        TextView NazivAutor = (TextView)v.findViewById(R.id.eAutor);
        TextView NazivDatumObjavljivanja = (TextView)v.findViewById(R.id.eDatumObjavljivanja);
        TextView NazivBrojStranica = (TextView) v.findViewById(R.id.eBrojStranica);
        TextView NazivOpis = (TextView)v.findViewById(R.id.eOpis);
        Button eButton = (Button)v.findViewById(R.id.eButton);

        ImageView SlikaKnjiga = (ImageView)v.findViewById(R.id.eNaslovna);
        NazivKnjiga.setText("Naziv: " + mKnjigaList.get(position).getNaziv());
        String authors="Autori: ";
        if(mKnjigaList.get(position).getAutori().size()!=0)
        authors+=mKnjigaList.get(position).getAutori().get(0).getImeiPrezime();
        for(int i=1;i<mKnjigaList.get(position).getAutori().size();i++)
        {
            authors+=", " + mKnjigaList.get(position).getAutori().get(i).getImeiPrezime();
        }

        NazivAutor.setText(authors);
        if(mKnjigaList.get(position).getDatumObjavljivanja()==null)
            NazivDatumObjavljivanja.setText("Datum: ");
        else
            NazivDatumObjavljivanja.setText("Datum: " + mKnjigaList.get(position).getDatumObjavljivanja());

        if(mKnjigaList.get(position).getBrojStranica()==0)
            NazivBrojStranica.setText("Stranica: ");
        else
            NazivBrojStranica.setText("Stranica: " + String.valueOf(mKnjigaList.get(position).getBrojStranica()));

        NazivOpis.setText("Opis: " + mKnjigaList.get(position).getOpis());
        if(mKnjigaList.get(position).getPoster()==null)
        {
            if(mKnjigaList.get(position).getSlika()!=null)
                Picasso.get().load(mKnjigaList.get(position).getSlika().toString()).into(SlikaKnjiga);

        }
        else
        {

            Bitmap b= null;


            try {
                Uri uri = Uri.parse(mKnjigaList.get(position).getPoster());
                b = MediaStore.Images.Media.getBitmap(mContext.getContentResolver(),uri);
            } catch (IOException e) {
                e.printStackTrace();
            }

            SlikaKnjiga.setImageBitmap(b);



            /*SlikaKnjiga.setImageBitmap(mKnjigaList.get(position).getPoster());*/
        }






        if(mKnjigaList.get(position).jelProcitana()==true)
           v.setBackgroundColor(v.getResources().getColor(R.color.colorLightBlue));

        eButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ((KategorijeAkt)mContext).editVrsta("FragmentPreporuci");
                FragmentManager fmjam = ((KategorijeAkt)mContext).getSupportFragmentManager();
                Fragment preporuci = new FragmentPreporuci();
                Bundle argument = new Bundle();
                argument.putParcelable("Knjiga",mKnjigaList.get(position));

                // BUNDLE
                preporuci.setArguments(argument);
                fmjam.beginTransaction().replace(R.id.frame_lijevo,  preporuci).commit();
            }
        });

        return v;
    }

    @Override
    public Filter getFilter() {
        if(cs==null)
        {
            cs=new CustomFilter();
        }
        return cs;
    }

    class CustomFilter extends Filter
    {

        @Override
        protected FilterResults performFiltering(CharSequence constraint) {
            FilterResults results = new FilterResults();

            if (constraint != null && constraint.length() > 0) {
                ArrayList<Knjiga> filterList = new ArrayList<Knjiga>();
                for (int i = 0; i < mKnjigaList.size(); i++) {
                    if ((mKnjigaList.get(i).getKategorijaKnjige().toUpperCase())
                            .contains(constraint.toString().toUpperCase())) {

                        Knjiga knjigadata = new Knjiga(mKnjigaList.get(i)
                                .getAutori(),mKnjigaList.get(i)
                                .getNaziv(), mKnjigaList.get(i)
                                .getKategorijaKnjige(),mKnjigaList.get(i)
                                .getPoster());

                        filterList.add(knjigadata);
                    }
                }
                results.count = filterList.size();
                results.values = filterList;
            } else {

                results.count = mKnjigaList.size();
                results.values = mKnjigaList;
            }
            return results;
        }

        @Override
        protected void publishResults(CharSequence constraint, FilterResults results) {
            mKnjigaList = (ArrayList<Knjiga>) results.values;
            notifyDataSetChanged();

        }
    }

}
