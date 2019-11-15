package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.content.Context;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

public class CustomAutorAdapter extends BaseAdapter {

    private Context mContext;
    private ArrayList<Autor> mAutorList;
    public CustomAutorAdapter(Context mContext, ArrayList<Autor> mAutorList) {
        this.mContext = mContext;
        this.mAutorList = mAutorList;

    }

    @Override
    public int getCount() {
        return mAutorList.size();
    }

    @Override
    public Autor getItem(int position) {
        return mAutorList.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {

        View v = view.inflate(mContext,R.layout.element_lista_autora,null);
        TextView eAutor = (TextView)v.findViewById(R.id.eAutor);
        TextView eBrojKnjigaAutora = (TextView)v.findViewById(R.id.eBrojKnjigaAutora);
        eAutor.setText(mAutorList.get(position).getImeiPrezime());
        eBrojKnjigaAutora.setText(String.valueOf(mAutorList.get(position).getBrojKnjiga()));

        return v;
    }
}

