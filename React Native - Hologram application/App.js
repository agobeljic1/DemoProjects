/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow
 */


import React, {Fragment} from 'react';


import {createAppContainer} from 'react-navigation';
import {createStackNavigator} from 'react-navigation-stack';
import VideoView from './components/VideoView.js';
import FileExplorer from './components/FileExplorer.js';
import ImageView from './components/ImageView.js';

const MainNavigator = createStackNavigator({
  Home: {screen: FileExplorer},
  Video: {screen: VideoView},
  Image: {screen: ImageView}  
},  
{
  headerMode: 'screen',
  cardStyle: { backgroundColor: '#ffffff' },
  
  
}
);

const App = createAppContainer(MainNavigator);


export default App;
