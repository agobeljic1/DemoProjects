import React, { Component } from 'react'
import {
    StyleSheet,
    View,
    Dimensions,
    BackHandler,
    Image
  } from 'react-native';
  import Orientation from 'react-native-orientation-locker';
  import FullScreen from "./FullScreen.js";

export class ImageView extends Component {
    static navigationOptions = {
        header:null,
    };     

    constructor(props) {
      super(props);
      this.state={}      
    }
    componentDidMount=()=>{
      BackHandler.addEventListener('hardwarebackPress',this.handleBackPress);
    }
    componentWillUnmount=()=>{
      BackHandler.removeEventListener('hardwarebackPress',this.handleBackPress);
    }

    handleBackPress = () =>
    {
      FullScreen.disable();
      Orientation.unlockAllOrientations();        
      return false;
    }      
    
    render() {

      FullScreen.enable();
      Orientation.lockToLandscape();      
      
      if(Math.round(Dimensions.get('window').width)>Math.round(Dimensions.get('window').height))
      {
          width = Math.round(Dimensions.get('window').width); 
          height = Math.round(Dimensions.get('window').height); 
      }
      else
      {
          width = Math.round(Dimensions.get('window').height); 
          height = Math.round(Dimensions.get('window').width); 
      }
        
      const styles = StyleSheet.create({
          styleFlex:{
            flexDirection: 'column',
            justifyContent: 'space-around',
            display:'flex',
            flex:1
            
          },
          rowStyle:{
            flexDirection: 'row',
            justifyContent: 'space-around',
            display:'flex',
            flex:1
          },
          style_1_1: {
            flex: Math.round((width/2.-height/6.)*100),
            backgroundColor:'black',
          },
          style_1_2: {
            flex: Math.round((height/3.)*100)
          },
          style_1_3: {
            flex: Math.round((width/2.-height/6.)*100),
            backgroundColor:'black',
          },
          style_2_1: {
            flex: Math.round((width/2.-7*height/12.)*100),
            backgroundColor:'black',
          },
          style_2_2: {
            flex: Math.round((height/3.)*100)
          },
          style_2_3: {
            flex: Math.round((height/2.)*100),
            backgroundColor:'black',
          },
          style_2_4: {
            flex: Math.round((height/3.)*100)
          },
          style_2_5: {
            flex: Math.round((width/2.-7*height/12.)*100),
            backgroundColor:'black',
          },
          style_3_1: {
            flex: Math.round((width/2.-height/6.)*100),
            backgroundColor:'black',
          },
          style_3_2: {
            flex: Math.round((height/3.)*100)
          },
          style_3_3: {
            flex: Math.round((width/2.-height/6.)*100),
            backgroundColor:'black',
          },
          imageStyle1:{
            width:undefined,height:undefined,resizeMode:"stretch",aspectRatio:1,
            transform: [{ rotate: '0deg'}]
          },
          imageStyle2:{
            width:undefined,height:undefined,resizeMode:"stretch",aspectRatio:1,
            transform: [{ rotate: '2700deg'}]
          },
          imageStyle3:{
            width:undefined,height:undefined,resizeMode:"stretch",aspectRatio:1,
            transform: [{ rotate: '90deg'}]
          },
          imageStyle4:{
            width:undefined,height:undefined,resizeMode:"stretch",aspectRatio:1,
            transform: [{ rotate: '180deg'}]
          }
        });

      const { navigation } = this.props;
      var putanja = navigation.getParam('putanja', 'file:///storage/emulated/0/Download/Raspored.png');

      return (
         <View style={styles.styleFlex}>
            <View style={styles.rowStyle}>
              <View style={styles.style_1_1}/>
              <View style={styles.style_1_2} >
                <Image style={styles.imageStyle1} source={{uri:putanja}}/>
              </View>
              <View style={styles.style_1_3}/>
            </View>
            <View style={styles.rowStyle}>
              <View style={styles.style_2_1}/>
              <View style={styles.style_2_2}>
                <Image style={styles.imageStyle2} source={{uri:putanja}}/>
              </View>
              <View style={styles.style_2_3}/>
              <View style={styles.style_2_4}>
                <Image style={styles.imageStyle3} source={{uri:putanja}}/>
              </View>
              <View style={styles.style_2_5}/>
            </View>
            <View style={styles.rowStyle}>
              <View style={styles.style_3_1}/>
              <View style={styles.style_3_2}>
                <Image style={styles.imageStyle4} source={{uri:putanja}}/>
              </View>
              <View style={styles.style_3_3}/>
            </View>
         </View>
      )
    }
}

export default ImageView

