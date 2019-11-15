import 'package:flutter/material.dart';
import 'package:hologram_diplomski/models/folder.dart';

class File{
  final String name;

  File({
    this.name
  });

  @override
  String toString() {
    // TODO: implement toString
    return this.name;
  }

}

// Videos


List<File> videosData = [
  File(
      name: "Video 1"
  ),
  File(
      name: "Video 2"
  ),
  File(
      name: "Video 3"
  ),
  File(
      name: "Video 4"
  )
];

//Images

List<File> imagesData = [
  File(
      name: "Image 1"
  ),
  File(
      name: "Image 2"
  ),
  File(
      name: "Image 3"
  ),
  File(
      name: "Image 4"
  )
];