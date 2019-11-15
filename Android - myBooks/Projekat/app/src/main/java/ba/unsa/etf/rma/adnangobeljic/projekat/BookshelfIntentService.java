package ba.unsa.etf.rma.adnangobeljic.projekat;

import android.app.IntentService;
import android.content.Intent;
import android.content.Context;
import android.os.Bundle;
import android.os.ResultReceiver;
import android.support.annotation.Nullable;

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

public class BookshelfIntentService extends IntentService {
    private ArrayList<Knjiga> knjigaSpinner = new ArrayList<Knjiga>();


    public BookshelfIntentService() {
        super(null);
    }

    public BookshelfIntentService(String name) { super(name);}

    public static final int STATUS_START = 0;
    public static final int STATUS_FINISH = 1;
    public static final int STATUS_ERROR = 2;

    @Override
    public void onCreate(){super.onCreate();}

    @Override
    protected void onHandleIntent(Intent intent) {
        String userID = intent.getStringExtra("idKorisnika");
        ResultReceiver receiver = intent.getParcelableExtra("receiver");

        Bundle bundle = new Bundle();
        receiver.send(STATUS_START,Bundle.EMPTY);




        String query = null;
        try
        {
            query= URLEncoder.encode(userID,"utf-8");
        }
        catch(UnsupportedEncodingException e)
        {
            e.printStackTrace();
        }

        String url1 = "https://www.googleapis.com/books/v1/users/" + query +"/bookshelves";
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
                if(volume.has("access") && volume.getString("access").equals("PUBLIC"))
                {
                    String id;
                    id=volume.getString("id");

                    {
                        String query1 = null;
                        try
                        {
                            query1= URLEncoder.encode(id,"utf-8");
                        }
                        catch(UnsupportedEncodingException e)
                        {
                            e.printStackTrace();
                        }
                        String url2 = "https://www.googleapis.com/books/v1/users/" + query +"/bookshelves/" + query1 + "/volumes";
                        try{
                            URL urL = new URL(url2);
                            HttpURLConnection urlConnectionn = (HttpURLConnection) urL.openConnection();
                            InputStream inn = new BufferedInputStream(urlConnectionn.getInputStream());
                            String rezultatt = convertStreamToString(inn);
                            JSONObject jo1 = new JSONObject(rezultatt);
                            JSONArray items1 = jo1.getJSONArray("items");

                            for(int j=0;j<items1.length();j++)
                            {
                                JSONObject volume1 = items1.getJSONObject(j);

                                String id1="";
                                String naziv1="";
                                if(volume1.has("id"))
                                    id1 = volume1.getString("id");

                                JSONObject volumeInfo1 = volume1.getJSONObject("volumeInfo");
                                if(volumeInfo1.has("title"))
                                    naziv1 = volumeInfo1.getString("title");


                                String autorKnjige1="";
                                ArrayList<Autor> autori1 = new ArrayList<Autor>();
                                if(volumeInfo1.has("authors")) {
                                    JSONArray authors1 = volumeInfo1.getJSONArray("authors");
                                    for (int j1 = 0; j1 < authors1.length(); j1++) {
                                        autorKnjige1 = authors1.getString(j1);
                                        Autor autorHelp1 = new Autor(autorKnjige1, id1);
                                        autori1.add(autorHelp1);

                                    }
                                }

                                String opis1="";
                                if(volumeInfo1.has("description"))
                                    opis1 = volumeInfo1.getString("description");
                                String datumObjavljivanja1 = volumeInfo1.getString("publishedDate");

                                int brojStranica1=0;

                                if(volumeInfo1.has("pageCount"))
                                    brojStranica1 = Integer.parseInt(volumeInfo1.getString("pageCount"));


                                URL slika1 = null;
                                if(volumeInfo1.has("imageLinks"))
                                {
                                    JSONObject imageLinks1 = volumeInfo1.getJSONObject("imageLinks");
                                    if(imageLinks1.has("smallThumbnail"))
                                        slika1 = new URL(imageLinks1.getString("smallThumbnail"));
                                }

                                knjigaSpinner.add(new Knjiga(id1,naziv1,autori1,opis1,datumObjavljivanja1,slika1,brojStranica1));
                            }
                        }
                        catch(MalformedURLException e)
                        {
                            e.printStackTrace();
                            bundle.putString(Intent.EXTRA_TEXT,e.toString());
                            receiver.send(STATUS_ERROR,bundle);
                            return;
                        }
                        catch(IOException e)
                        {
                            e.printStackTrace();
                            bundle.putString(Intent.EXTRA_TEXT,e.toString());
                            receiver.send(STATUS_ERROR,bundle);
                            return;
                        }
                        catch(JSONException e)
                        {
                            e.printStackTrace();
                            bundle.putString(Intent.EXTRA_TEXT,e.toString());
                            receiver.send(STATUS_ERROR,bundle);
                            return;
                        }
                    }
                }
                else
                    continue;
            }
        }
        catch(MalformedURLException e)
        {
            e.printStackTrace();
            bundle.putString(Intent.EXTRA_TEXT,e.toString());
            receiver.send(STATUS_ERROR,bundle);
            return;
        }
        catch(IOException e)
        {
            e.printStackTrace();
            bundle.putString(Intent.EXTRA_TEXT,e.toString());
            receiver.send(STATUS_ERROR,bundle);
            return;
        }
        catch(JSONException e)
        {
            e.printStackTrace();
            bundle.putString(Intent.EXTRA_TEXT,e.toString());
            receiver.send(STATUS_ERROR,bundle);
            return;

        }
        bundle.putParcelableArrayList("Knjige",knjigaSpinner);
        receiver.send(STATUS_FINISH,bundle);



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
