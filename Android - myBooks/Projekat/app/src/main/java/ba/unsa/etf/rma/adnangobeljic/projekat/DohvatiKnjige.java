package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.content.pm.ActivityInfo;
import android.content.res.Configuration;
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

public class DohvatiKnjige extends AsyncTask<String,Integer, Void> {

    public interface IDohvatiKnjigeDone
    {
        public void onDohvatiDone(ArrayList<Knjiga> knjige);
    }
    private IDohvatiKnjigeDone pozivatelj;

    public DohvatiKnjige(IDohvatiKnjigeDone p){pozivatelj=p;};

    public ArrayList<Knjiga> knjigaSpinner = new ArrayList<Knjiga>();




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
        String url1 = "https://www.googleapis.com/books/v1/volumes?q=intitle:" + query +"&maxResults=5";
        try{
            URL url = new URL(url1);
            HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
            /*urlConnection.setRequestProperty("Authorization","Bearer " + "BQC7ty9YM6dnfnHCLxg-qD0CmlqMUSZ5xLIJYHt9WbmqlSBPYclmDF2Dh5fu0Z6DDpFl1YfnGhyf2Y-qAsM_Wg0YLVQqbPKrPTlnqWodL7m7GMvPZA37QO4DKu0F39hCpw8QGyt5AKKIx1SHzC5GJAPnWgnilIQ" );*/
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



/*
                if(!naziv.equals(query))
                    continue;
*/


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
        pozivatelj.onDohvatiDone(knjigaSpinner);

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
