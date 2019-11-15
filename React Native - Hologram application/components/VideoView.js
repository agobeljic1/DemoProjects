import React, { Component } from 'react'
import {
    StyleSheet,
    View,
    Dimensions,
    BackHandler,  
    ToastAndroid
  } from 'react-native';
  import Orientation from 'react-native-orientation-locker';
  import FullScreen from "./FullScreen.js";
  import Video from 'react-native-video';
export class VideoView extends Component {
    static navigationOptions = {
        header:null,
    };

    constructor(props) {
      super(props);
      this.state=
      {
        videoBroj:0,
        paused:true
      }
      this.video1=Video;
      this.video2=Video;
      this.video3=Video;
      this.video4=Video;
    }

    onLoadVideo=()=>
    {      
      if(this.state.videoBroj>=2)
      {
        this.setState({paused:false});
      }      
      else
      {
        this.setState({videoBroj:this.state.videoBroj+1});
      }
      
      
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
          flex: Math.round((height/3.)*100),
          backgroundColor:'black'
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
          flex: Math.round((height/3.)*100),
          backgroundColor:'black'
        },
        style_2_3: {
          flex: Math.round((height/2.)*100),
          backgroundColor:'black',
        },
        style_2_4: {
          flex: Math.round((height/3.)*100),
          backgroundColor:'black'
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
          flex: Math.round((height/3.)*100),
          backgroundColor:'black'
        },
        style_3_3: {
          flex: Math.round((width/2.-height/6.)*100),
          backgroundColor:'black'
        },
        videoScreen1:{
          width:undefined,height:undefined,aspectRatio:1,
          transform: [{ rotate: '0deg'}]         
        },
        videoScreen2:{
          width:undefined,height:undefined,aspectRatio:1,
          transform: [{ rotate: '270deg'}]         
        },
        videoScreen3:{
          width:undefined,height:undefined,aspectRatio:1,
          transform: [{ rotate: '90deg'}]         
        },
        videoScreen4:{
          width:undefined,height:undefined,aspectRatio:1,
          transform: [{ rotate: '180deg'}]         
        }
      });

      const { navigation } = this.props;
      var putanja = navigation.getParam('putanja', 'file:///storage/emulated/0/DCIM/Camera/videooo.mp4');
      return (         
        <View style={styles.styleFlex}>
          <View style={styles.rowStyle}>
            <View style={styles.style_1_1}/>
            <View style={styles.style_1_2}>
              <Video
                ref={(ref: Video) => { this.video1 = ref }}
                source={{ uri: navigation.getParam('putanja', 'file:///storage/emulated/0/DCIM/Camera/videooo.mp4') }} 
                style={styles.videoScreen1}
                muted={false}          
                repeat={true}
                resizeMode={"cover"}
                onLoad={()=>this.onLoadVideo()}
                paused={this.state.paused}
              />
            </View>             
            <View style={styles.style_1_3}/>
          </View>
          <View style={styles.rowStyle}>
            <View style={styles.style_2_1}/>
            <View style={styles.style_2_2}>
              <Video
                ref={(ref: Video) => { this.video2 = ref }}
                source={{ uri: navigation.getParam('putanja', 'file:///storage/emulated/0/DCIM/Camera/videooo.mp4') }} 
                style={styles.videoScreen2}
                muted={true}
                repeat={true}
                resizeMode={"cover"}
                onLoad={()=>this.onLoadVideo()}
                paused={this.state.paused}
              />
            </View>
            <View style={styles.style_2_3}/>
            <View style={styles.style_2_4}>
              <Video
                ref={(ref: Video) => { this.video3 = ref }}
                source={{ uri: navigation.getParam('putanja', 'file:///storage/emulated/0/DCIM/Camera/videooo.mp4') }} 
                style={styles.videoScreen3}
                muted={true}
                repeat={true}
                resizeMode={"cover"}
                onLoad={()=>this.onLoadVideo()}
                paused={this.state.paused}
              />
            </View>
            <View style={styles.style_2_5}/>
          </View>
          <View style={styles.rowStyle}>
            <View style={styles.style_3_1}/>
            <View style={styles.style_3_2}>
              <Video
                ref={(ref: Video) => { this.video4 = ref }}
                source={{ uri: navigation.getParam('putanja', 'file:///storage/emulated/0/DCIM/Camera/videooo.mp4') }} 
                style={styles.videoScreen4}
                muted={true}
                repeat={true}
                resizeMode={"cover"}
                onLoad={()=>this.onLoadVideo()}
                paused={this.state.paused}
              />
            </View>
            <View style={styles.style_3_3}/>
          </View>
        </View>
      )
    }
}

export default VideoView
