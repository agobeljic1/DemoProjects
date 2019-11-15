package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.os.Parcel;
import android.os.Parcelable;

import java.util.ArrayList;

public class Autor implements Parcelable{




    private String imeiPrezime;
    private ArrayList<String> knjige;

    public Autor(String imeiPrezime, ArrayList<String> knjige)
    {
        this.imeiPrezime=imeiPrezime;
        this.knjige=knjige;
    }
    public Autor(String imeiPrezime,String knjiga)
    {
        this.imeiPrezime=imeiPrezime;
        knjige=new ArrayList<String>();
        knjige.add(knjiga);

    }





    public Autor() {}



    public String getImeiPrezime() {
        return imeiPrezime;
    }

    public void setImeiPrezime(String imeAutora) {
        this.imeiPrezime = imeAutora;
    }


    public ArrayList<String> getKnjige() { return knjige; }

    public void setKnjige(ArrayList<String> knjige) { this.knjige = knjige; }


    public int getBrojKnjiga() {
        return knjige.size();
    }

    public void dodajKnjigu(String id)
    {
        if(!knjige.contains(id)) knjige.add(id);
    }

    protected Autor(Parcel in) {

        imeiPrezime = in.readString();
        knjige=in.createStringArrayList();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {

        dest.writeString(imeiPrezime);
        dest.writeStringList(knjige);

    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Autor> CREATOR = new Parcelable.Creator<Autor>() {
        @Override
        public Autor createFromParcel(Parcel in) {
            return new Autor(in);
        }

        @Override
        public Autor[] newArray(int size) {
            return new Autor[size];
        }
    };




}
