package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.graphics.Bitmap;
import android.media.Image;
import android.net.Uri;
import android.os.Parcel;
import android.os.Parcelable;

import java.io.Serializable;
import java.net.DatagramPacket;
import java.net.URI;
import java.net.URL;
import java.util.ArrayList;

/**
 * Created by PC on 3/28/2018.
 */

public class Knjiga implements Parcelable{
    private String id;
    private String naziv;
    private ArrayList<Autor> autori = new ArrayList<Autor>();
    private String opis;
    private String datumObjavljivanja;
    private URL slika;
    private int brojStranica;
    private boolean procitan;
    private String poster;
    private String kategorija;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNaziv() {
        return naziv;
    }

    public void setNaziv(String naziv) {
        this.naziv = naziv;
    }

    public ArrayList<Autor> getAutori() {
        return autori;
    }

    public void setAutori(ArrayList<Autor> autori) {
        this.autori = autori;
    }

    public String getOpis() {
        return opis;
    }

    public void setOpis(String opis) {
        this.opis = opis;
    }

    public String getDatumObjavljivanja() {
        return datumObjavljivanja;
    }

    public void setDatumObjavljivanja(String datumObjavljivanja) {
        this.datumObjavljivanja = datumObjavljivanja;
    }

    public URL getSlika() {
        return slika;
    }

    public void setSlika(URL slika) {
        this.slika = slika;
    }

    public int getBrojStranica() {
        return brojStranica;
    }

    public void setBrojStranica(int brojStranica) {
        this.brojStranica = brojStranica;
    }

    public boolean jelProcitana() {
        return procitan;
    }

    public void oznaciProcitanom() {
        this.procitan = true;
    }
/*
    public Bitmap getPoster() {
        return poster;
    }

    public void setPoster(Bitmap poster) {
        this.poster = poster;
    }*/

    public String getPoster() {
        return poster;
    }

    public void setPoster(String poster) {
        this.poster = poster;
    }



    public String getKategorijaKnjige() { return kategorija; }

    public void setKategorijaKnjige(String kategorija) { this.kategorija = kategorija; }

    public void changeNAuthor(int a,Autor author)
    {
        autori.set(a,author);
    }




    public Knjiga(String id, String naziv, ArrayList<Autor> autori,String opis,String datumObjavljivanja,URL slika,int brojStranica)
    {
        this.id=id;
        this.naziv=naziv;
        this.autori=autori;
        this.opis=opis;
        this.datumObjavljivanja=datumObjavljivanja;
        this.slika=slika;
        this.brojStranica=brojStranica;
        this.procitan=false;
        this.kategorija="";
    }


    public Knjiga(String id, String naziv, ArrayList<Autor> autori,String opis,String datumObjavljivanja,URL slika,int brojStranica,boolean procitan) {
        this.id=id;
        this.naziv=naziv;
        this.autori=autori;
        this.opis=opis;
        this.datumObjavljivanja=datumObjavljivanja;
        this.slika=slika;
        this.brojStranica=brojStranica;
        this.procitan=procitan;
        this.kategorija="";
    }

    public Knjiga(String id, String naziv, ArrayList<Autor> autori,String opis,String datumObjavljivanja,URL slika,int brojStranica,boolean procitan,String poster, String kategorija) {
        this.id=id;
        this.naziv=naziv;
        this.autori=autori;
        this.opis=opis;
        this.datumObjavljivanja=datumObjavljivanja;
        this.slika=slika;
        this.brojStranica=brojStranica;
        this.procitan=procitan;
        this.kategorija=kategorija;
        this.poster=poster;
    }

    public Knjiga() {this.kategorija="";this.procitan=false;this.id="";}


    public Knjiga(ArrayList<Autor> autori,String naziv,String kategorija,String poster)
    {
        this.id=naziv+kategorija;
        this.autori=autori;
        this.naziv=naziv;
        this.kategorija=kategorija;
        this.poster=poster;
    }

    public Knjiga(String id,ArrayList<Autor> autori,String naziv,String kategorija,String poster)
    {
        this.id=id;
        this.autori=autori;
        this.naziv=naziv;
        this.kategorija=kategorija;
        this.poster=poster;
        this.datumObjavljivanja = "";
        this.opis = "";
    }


    protected Knjiga(Parcel in) {
        id = in.readString();
        naziv = in.readString();
        autori = in.readArrayList(Autor.class.getClassLoader());
        opis=in.readString();
        datumObjavljivanja=in.readString();
        slika=in.readParcelable(URL.class.getClassLoader());
        brojStranica=in.readInt();
        procitan=in.readByte()!=0;
        poster=in.readString();
        kategorija=in.readString();
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeString(id);
        dest.writeString(naziv);
        dest.writeList(autori);
        dest.writeString(opis);
        dest.writeString(datumObjavljivanja);
        dest.writeValue(slika);
        dest.writeInt(brojStranica);
        dest.writeByte((byte) (procitan ? 1 : 0));
        dest.writeString(poster);
        dest.writeString(kategorija);

    }

    @SuppressWarnings("unused")
    public static final Parcelable.Creator<Knjiga> CREATOR = new Parcelable.Creator<Knjiga>() {
        @Override
        public Knjiga createFromParcel(Parcel in) {
            return new Knjiga(in);
        }

        @Override
        public Knjiga[] newArray(int size) {
            return new Knjiga[size];
        }
    };












}
