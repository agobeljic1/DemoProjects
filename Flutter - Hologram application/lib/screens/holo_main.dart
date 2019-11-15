import 'package:flutter/material.dart';
import 'package:hologram_diplomski/models/folder.dart';
import 'package:hologram_diplomski/models/file.dart';
import 'package:hologram_diplomski/screens/imageDisplay.dart';
import 'package:hologram_diplomski/screens/videoDisplay.dart';
import 'package:file_picker/file_picker.dart';
import 'package:path_provider/path_provider.dart';
import 'package:tuple/tuple.dart';
import 'package:permission_handler/permission_handler.dart';
import 'dart:async';
import 'dart:developer';
import 'package:flutter/foundation.dart';

import 'package:flutter/services.dart';
import 'dart:io';

class HoloMain extends StatefulWidget {
  @override
  _HoloMainState createState() => _HoloMainState();
}

class _HoloMainState extends State<HoloMain> {
  static const VIDEOSSCREEN_INDEX=0;
  static const IMAGESSCREEN_INDEX=1;
  List<List<File>> stateManager_imagesData = new List<List<File>>();
  List<List<File>> stateManager_videosData = new List<List<File>>();
  List<List<Folder>> stateManager_foldersData = new List<List<Folder>>();
  bool stateManager_statusBool=false;
  bool stateManager_zavrsenGet=false;

  int _currentIndex = 0;


      _onTapped(int index) {
    setState(() {
      _currentIndex = index;
    });
  }

  backToPreviousState() {
    if (stateManager_foldersData.length > 1) {
      setState(() {
        stateManager_foldersData.removeLast();
        stateManager_videosData.removeLast();
        stateManager_imagesData.removeLast();
      });
    }
  }


  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    PermissionHandler().requestPermissions([PermissionGroup.storage]).then(initDirectory);

  }

  void initDirectory(Map<PermissionGroup,PermissionStatus> statuses)
  {
    bool statusBool=statuses[PermissionGroup.storage].value==PermissionStatus.granted.value;
    if(statusBool==true)
      {
        Tuple3<List<Folder>,List<File>,List<File>> fileList = getFiles(new Directory('/storage/emulated/0'));
        setState(() {
          stateManager_foldersData.add(fileList.item1);
          stateManager_imagesData.add(fileList.item2);
          stateManager_videosData.add(fileList.item3);
          stateManager_statusBool=statusBool;
        });
      }
  }

  Tuple3<List<Folder>,List<File>,List<File>> getFiles(Directory directoryParam)
  {
    List<Folder> folderList = new List<Folder>();  // item1
    List<File> imageList = new List<File>();       // item2
    List<File> videoList = new List<File>();       // item3

    var fileList = new List<String>();
    var _files = directoryParam.listSync(recursive: false, followLinks: false);
    for(int i=0;i<_files.length;i++)
    {

      if(_files[i].runtimeType.toString()=='_File')
      {
        if(_files[i].path.endsWith('.mp4') || _files[i].path.endsWith('.avi') || _files[i].path.endsWith('.wmv'))
          videoList.add(new File(name: _files[i].path));

        if(_files[i].path.endsWith('.png') || _files[i].path.endsWith('.jpg') || _files[i].path.endsWith('.jpeg') || _files[i].path.endsWith('.bmp'))
          imageList.add(new File(name: _files[i].path));

      }
      if(_files[i].runtimeType.toString()=='_Directory')
      {
        var gottenFiles = getFiles(new Directory(_files[i].path));

        folderList.add(new Folder(
            name: _files[i].path,
            insideFolders: gottenFiles.item1,
            insideImages: gottenFiles.item2,
            insideVideos: gottenFiles.item3
        ));
      }
    }
    return new Tuple3<List<Folder>,List<File>,List<File>>(folderList,imageList,videoList);
  }

  String parsePath(String path)
  {
    var array = path.split("/");
    return array[array.length-1];
  }



  @override
  Widget build(BuildContext context) {
    if(!stateManager_statusBool)
    {
      return Scaffold();
    }

    SystemChrome.setPreferredOrientations([
      DeviceOrientation.landscapeRight,
      DeviceOrientation.landscapeLeft,
      DeviceOrientation.portraitDown,
      DeviceOrientation.portraitUp
    ]);
    SystemChrome.setEnabledSystemUIOverlays(SystemUiOverlay.values);
        var back_logo;
        if(stateManager_foldersData.length<=1)
          back_logo=Text("Holo UI");
        else
          back_logo= InkWell(
              onTap: (){
                backToPreviousState();
              },
              child:
              Icon(Icons.arrow_back)
          );

        var fileIcon;
        var dataList;
        if(_currentIndex==VIDEOSSCREEN_INDEX)
          {
            fileIcon=Icon(Icons.music_video,
                size:40.0);
            dataList=stateManager_videosData[stateManager_videosData.length-1];
          }
        else
          {
            fileIcon=Icon(Icons.image,
                size:40.0);
            dataList=stateManager_imagesData[stateManager_imagesData.length-1];
          }




    return Scaffold(

      appBar:AppBar(
        title:back_logo,
        backgroundColor: Colors.red,
      ),
      body:
        ListView.separated(itemBuilder: (context,index)
        {
          if(index<stateManager_foldersData[stateManager_foldersData.length-1].length)
          {
            return
              InkWell(
                  onTap: (){
                    setState((){
                      stateManager_imagesData.add(stateManager_foldersData[stateManager_foldersData.length-1][index].insideImages);
                      stateManager_videosData.add(stateManager_foldersData[stateManager_foldersData.length-1][index].insideVideos);
                      stateManager_foldersData.add(stateManager_foldersData[stateManager_foldersData.length-1][index].insideFolders);
                       });
                  },
                  child:
                  ListTile(
                      leading: Icon(Icons.folder,
                          size:40.0),
                      title: Text(parsePath(stateManager_foldersData[stateManager_foldersData.length-1][index].name)
                      )
                  )
              );
          }
          else
          {
            return InkWell(
                onTap: (){
                  if(_currentIndex==IMAGESSCREEN_INDEX)
                    Navigator.of(context).push(MaterialPageRoute(builder: (context) =>ImageDisplay(path:dataList[index-stateManager_foldersData[stateManager_foldersData.length-1].length].name)));
                  if(_currentIndex==VIDEOSSCREEN_INDEX)
                    Navigator.of(context).push(MaterialPageRoute(builder: (context) =>VideoDisplay(path:dataList[index-stateManager_foldersData[stateManager_foldersData.length-1].length].name)));

                  print(dataList[index-stateManager_foldersData[stateManager_foldersData.length-1].length].name);
                },
                child:
                ListTile(
                    leading: fileIcon,
                    title: Text(parsePath(dataList[index-stateManager_foldersData[stateManager_foldersData.length-1].length].name)
                    )
                )
            );
          }
        },
    separatorBuilder: (context,index) => Divider(
    height: 1.0,
    color: Colors.grey),
    itemCount: dataList.length+stateManager_foldersData[stateManager_foldersData.length-1].length)
        ,
      bottomNavigationBar: BottomNavigationBar(
        currentIndex: _currentIndex,
        backgroundColor: Colors.red,
        type: BottomNavigationBarType.fixed,
        fixedColor: Colors.white,
        onTap: _onTapped,
        items: [
        BottomNavigationBarItem(title:Text("Videos"),icon: Icon(Icons.videocam)),
        BottomNavigationBarItem(title:Text("Images"),icon: Icon(Icons.image))
      ],




      )
    );
  }
}
