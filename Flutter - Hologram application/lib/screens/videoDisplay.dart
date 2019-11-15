import 'package:flutter/material.dart';

import 'package:hologram_diplomski/models/folder.dart';
import 'package:file_picker/file_picker.dart';
import 'package:path_provider/path_provider.dart';
import 'package:tuple/tuple.dart';
import 'package:permission_handler/permission_handler.dart';
import 'dart:async';
import 'package:flutter/services.dart';
import 'dart:io';
import 'package:hologram_diplomski/screens/videoPlaya.dart';


class VideoDisplay extends StatelessWidget {
  String path;

  VideoDisplay(
      {
        this.path
      }
      );

  @override
  Widget build(BuildContext context) {

    double pi=3.141593;
    double width = MediaQuery.of(context).size.width;
    double height = MediaQuery.of(context).size.height;
    SystemChrome.setEnabledSystemUIOverlays([]);
    SystemChrome.setPreferredOrientations([
      DeviceOrientation.landscapeRight,
      DeviceOrientation.landscapeLeft,
    ]);
    return new MaterialApp(
        title:"Hologram",
        home: Scaffold(
            body: Container(
              height: double.infinity,
              width: double.infinity,
              alignment: Alignment.center,
              child:
              Column(children:[
                Flexible(flex:1,
                    fit:FlexFit.tight,
                    child:Row(children:[
                      Flexible(flex:((width/2-height/6)*100).truncate(),
                          fit:FlexFit.tight,
                          child:Container(
                              color:Colors.black)),
                      Flexible(flex:((height/3)*100).truncate(),
                          child:Transform.rotate(angle: 0, child: VideoPlayerScreen(myPath:this.path,myVolume: 1))),
                      Flexible(flex:((width/2-height/6)*100).truncate(),
                          child:Container(color:Colors.black))
                    ])
                ),
                Flexible(flex:1,
                  fit:FlexFit.tight,
                  child:Row(children:[
                    Flexible(flex:((width/2-7*height/12)*100).truncate(),
                        fit:FlexFit.tight,
                        child:Container(
                            color:Colors.black)),
                    Flexible(flex:((height/3)*100).truncate(),
                        child:Transform.rotate(angle: -pi/2, child: VideoPlayerScreen(myPath:this.path,myVolume: 0))),
                    Flexible(flex:((height/2)*100).truncate(),
                        child:Container(color:Colors.black)),
                    Flexible(flex:((height/3)*100).truncate(),
                        child:Transform.rotate(angle: pi/2, child: VideoPlayerScreen(myPath:this.path,myVolume: 0))),
                    Flexible(flex:((width/2-7*height/12)*100).truncate(),
                        child:Container(color:Colors.black))
                  ]),
                ),
                Flexible(flex:1,
                    fit:FlexFit.tight,
                    child: Row(children:[
                      Flexible(flex:((width/2-height/6)*100).truncate(),
                          fit:FlexFit.tight,
                          child:Container(
                              color:Colors.black)),
                      Flexible(flex:((height/3)*100).truncate(),
                          child:Transform.rotate(angle: pi, child: VideoPlayerScreen(myPath:this.path,myVolume: 0))),
                      Flexible(flex:((width/2-height/6)*100).truncate(),
                          child:Container(color:Colors.black))
                    ])
                )
              ]),


            )
        )
    );
  }
}
