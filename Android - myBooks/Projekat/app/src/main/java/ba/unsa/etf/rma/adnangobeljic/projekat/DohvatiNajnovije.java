package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.os.AsyncTask;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.Date;

public class DohvatiNajnovije extends AsyncTask<String,Integer, Void> {
    public interface IDohvatiNajnovijeDone
    {
        public void onNajnovijeDone(ArrayList<Knjiga> knjige);
    }
    private IDohvatiNajnovijeDone pozivatelj;

    public DohvatiNajnovije(IDohvatiNajnovijeDone p){pozivatelj=p;};

    public ArrayList<Knjiga> knjigaSpinner = new ArrayList<Knjiga>();
    String a;



    @Override
    protected Void doInBackground(String... strings) {
        String query = null;
        try
        {
            query= URLEncoder.encode(strings[0],"utf-8");
        }
        catch(UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }
String helper="";
        for(int i=0;i<query.length();i++)
        {
            if(query.charAt(i)==' ')
            {
                helper = helper + "%20";
            }
            else
                helper = helper + query.charAt(i);
        }
        query = helper;




        String url1 = "https://www.googleapis.com/books/v1/volumes?q=inauthor:" + query+ "&orderBy=newest&maxResults=5";
        try{
            URL url = new URL(url1);
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();

            InputStream in = new BufferedInputStream(urlConnection.getInputStream());
            String rezultat = convertStreamToString(in);
            JSONObject jo = new JSONObject(rezultat);
            JSONArray items = jo.getJSONArray("items");



            for(int i=0;i<items.length();i++)
            {
                JSONObject volume = items.getJSONObject(i);

                String id="";
                String naziv="";
                if(volume.has("id"))
                    id = volume.getString("id");

                JSONObject volumeInfo = volume.getJSONObject("volumeInfo");
                if(volumeInfo.has("title"))
                    naziv = volumeInfo.getString("title");


                String autorKnjige="";
                ArrayList<Autor> autori = new ArrayList<Autor>();
                if(volumeInfo.has("authors")) {
                    JSONArray authors = volumeInfo.getJSONArray("authors");
                    for (int j = 0; j < authors.length(); j++) {
                        autorKnjige = authors.getString(j);
                        Autor autorHelp = new Autor(autorKnjige, id);
                        autori.add(autorHelp);

                    }
                }

                String opis="";
                if(volumeInfo.has("description"))
                    opis = volumeInfo.getString("description");

                String datumObjavljivanja = "";
                if(volumeInfo.has("publishedDate"))
                    datumObjavljivanja = volumeInfo.getString("publishedDate");

                int brojStranica=0;

                if(volumeInfo.has("pageCount"))
                    brojStranica = Integer.parseInt(volumeInfo.getString("pageCount"));


                URL slika = null;
                if(volumeInfo.has("imageLinks"))
                {
                    JSONObject imageLinks = volumeInfo.getJSONObject("imageLinks");
                    if(imageLinks.has("smallThumbnail"))
                        slika = new URL(imageLinks.getString("smallThumbnail"));
                }

                knjigaSpinner.add(new Knjiga(id,naziv,autori,opis,datumObjavljivanja,slika,brojStranica));







            }
        }
        catch(MalformedURLException e)
        {
            e.printStackTrace();
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
        catch(JSONException e)
        {
            e.printStackTrace();
        }
        return null;

    }

    @Override
    protected void onPostExecute(Void aVoid) {
        super.onPostExecute(aVoid);
        pozivatelj.onNajnovijeDone(knjigaSpinner);
    }

    public String convertStreamToString(InputStream is)
    {
        BufferedReader reader = new BufferedReader(new InputStreamReader(is));
        StringBuilder sb = new StringBuilder();
        String line = null;
        try{
            while((line=reader.readLine())!=null)
            {
                sb.append(line + "\n");
            }
        }
        catch(IOException e)
        {
        }
        finally {
            try{
                is.close();
            }
            catch (IOException e){

            }
        }
        return sb.toString();
    }
}

