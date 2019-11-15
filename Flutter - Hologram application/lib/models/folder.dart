import 'package:flutter/material.dart';
import 'package:hologram_diplomski/models/file.dart';

class Folder {
  final String name;
  final List<Folder> insideFolders;
  final List<File> insideImages;
  final List<File> insideVideos;


  Folder({
    this.name,
    this.insideFolders,
    this.insideImages,
    this.insideVideos
  });

  @override
  String toString() {
    // TODO: implement toString
    return this.name;
  }

}

List<Folder> foldersData = [
  Folder(
      name: "Folder 1",
      insideFolders: new List<Folder>(),
      insideImages: new List<File>(),
      insideVideos: new List<File>()
  ),
  Folder(
      name: "Folder 2",
      insideFolders: new List<Folder>(),
      insideImages: new List<File>(),
      insideVideos: new List<File>()
  ),
  Folder(
      name: "Folder 3",
      insideFolders: new List<Folder>(),
      insideImages: new List<File>(),
      insideVideos: new List<File>()
  ),
  Folder(
      name: "Folder 4",
      insideFolders: new List<Folder>(),
      insideImages: new List<File>(),
      insideVideos: new List<File>()
  )
];
