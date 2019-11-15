import 'package:flutter/material.dart';
import 'package:hologram_diplomski/screens/holo_main.dart';
import 'appbar_back_1.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context){
    return new MaterialApp(
      title:"Hologram",
      home:HoloMain(),
      color:Colors.red,
    );
  }
}
