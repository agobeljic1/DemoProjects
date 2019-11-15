
import React, {Component} from 'react';
import {
  StyleSheet,
  ScrollView,
  View,
  Text,
  FlatList,
  TouchableWithoutFeedback,
  TouchableNativeFeedback,
  PermissionsAndroid
} from 'react-native';
import Icon from 'react-native-vector-icons/MaterialCommunityIcons';
import RNFetchBlob from 'react-native-fetch-blob';
import Orientation from 'react-native-orientation-locker';
import FullScreen from "./FullScreen.js";

 


export class FileExplorer extends Component {
  static navigationOptions =
  {
    header:null,
  };
  constructor(props)
  {
    super(props);
    this.state =
    {
      trenutnaPutanja: '/storage/emulated/0',
      spisakFajlova:[],
      indexPressed:0,
      statusStorage:false
    };
  }

  request_permission= async () =>
  {
    try {
      const granted1 = await PermissionsAndroid.request(
        PermissionsAndroid.PERMISSIONS.READ_EXTERNAL_STORAGE,
       
      );
      if (granted1 === PermissionsAndroid.RESULTS.GRANTED) {
        console.log('You can use the camera');
        try {
          const granted2 = await PermissionsAndroid.request(
            PermissionsAndroid.PERMISSIONS.WRITE_EXTERNAL_STORAGE,
            
          );
          if (granted2 === PermissionsAndroid.RESULTS.GRANTED) {
            this._getFiles(this.state.trenutnaPutanja); 
            this.setState({statusStorage:true});
            console.log('You can use the camera');
          } else {
            console.log('Camera permission denied');
          }
        } catch (err1) {
          console.warn(err1);
        }
      } else {
        console.log('Camera permission denied');
      }
    } catch (err2) {
      console.warn(err2);
    }
    
    

  }

  _getFiles=(putanja)=>
  {
    if(this)
    RNFetchBlob.fs.ls(putanja)
    .then((files) => {
      console.log(files);
      var fajlovi=[];
      for(var i=0;i<files.length;i++)
      {
        if(files[i].split('.').length>1)
        {
          if(files[i].endsWith('.png') || files[i].endsWith('.jpg') || files[i].endsWith('.jpeg') || files[i].endsWith('.bmp'))
          fajlovi.push(
          {
            name:files[i],
            type: 'image'
          });
          if(files[i].endsWith('.mp4') || files[i].endsWith('.avi') || files[i].endsWith('.wmv'))
          fajlovi.push(
          {
            name: files[i],
            type: 'video'
          });          
        }
        else
        {
          fajlovi.push(
          {
            name: files[i],
            type: 'folder'
          });
        }
      }
      this.setState({spisakFajlova:fajlovi,trenutnaPutanja:putanja});     
    })
  }

  componentDidMount = async ()=>
  {
    await this.request_permission();       
  }

  _onPressButtonBottom=(broj)=>
  {
    this.setState({indexPressed:broj});
  }
  _onPressButton=(title,type)=>
  {
    const {navigate} = this.props.navigation;
    if(type=='folder')
    {
      this._getFiles(this.state.trenutnaPutanja+'/'+title); 
    }
    else
    {
      if(type=='video')
        navigate('Video', {putanja:'file://' + this.state.trenutnaPutanja+'/'+title});
      if(type=='image')
        navigate('Image', {putanja:'file://' + this.state.trenutnaPutanja+'/'+title});
    }
       
  }
  _onPressButtonTop=()=>{

    var mjesec = new Date().getMonth() + 1; // trenutni mjesec   
      

    
    var putanja=this.state.trenutnaPutanja;
    var dijelovi=putanja.split('/');
    var duzina=dijelovi.length;
    var noviString='';
    for(var t=1;t<duzina-1;t++)
      noviString+='/'+dijelovi[t];
    this._getFiles(noviString);
  }
  
  Item = ({title,type}) =>{
    if((this.state.indexPressed==0 && type=='image') || (this.state.indexPressed==1 && type=='video'))
    {
      return <View style={{display:'none'}}></View>;
    }
    return (
    <TouchableNativeFeedback onPress={()=>this._onPressButton(title,type)} background={TouchableNativeFeedback.SelectableBackground()}>
      <View style={styles.item} >
        <Icon size={45} style={styles.fileTypeIcon} name={type}></Icon>
        <Text style={styles.title}>{title}</Text>
      </View>
    </TouchableNativeFeedback>
    );
  }
  
  render() {
    if(!this.state.statusStorage)
    return <View/>;

    Orientation.unlockAllOrientations();
    FullScreen.disable();
      
    var bottomFirstStyle;
    var bottomSecondStyle;
    var bottomFirstStyleIcon;
    var bottomSecondStyleIcon;
    if(this.state.indexPressed==0)
    {
      bottomFirstStyle=styles.whiteStyle;
      bottomSecondStyle=styles.greyStyle;
      bottomFirstStyleIcon=styles.whiteStyleIcon;
      bottomSecondStyleIcon=styles.greyStyleIcon;
    }
    else
    {
      bottomFirstStyle=styles.greyStyle;
      bottomSecondStyle=styles.whiteStyle;
      bottomFirstStyleIcon=styles.greyStyleIcon;
      bottomSecondStyleIcon=styles.whiteStyleIcon;
    }
       
    var komponentaNaslov=(<Text style={{color:'white',fontSize:20,fontWeight:'bold'}}>Holo UI</Text>);
    if(this.state.trenutnaPutanja!='/storage/emulated/0')
    {
      komponentaNaslov=(
      <TouchableWithoutFeedback onPress={()=>this._onPressButtonTop()} background={TouchableNativeFeedback.SelectableBackground()}>                 
        <Icon style={styles.bottomTopIcon} name="arrow-left" size={25} />
      </TouchableWithoutFeedback>
      );
    }
    var najnovijiSpisak1=[];
    var najnovijiSpisak2=[];
    var najnovijiSpisak3=[];
    for(var f=0;f<this.state.spisakFajlova.length;f++)
    {
      if(this.state.spisakFajlova[f].type=='folder')
        najnovijiSpisak1.push(this.state.spisakFajlova[f]);

      if(this.state.indexPressed==0 && this.state.spisakFajlova[f].type=='video')
        najnovijiSpisak2.push(this.state.spisakFajlova[f]);

      if(this.state.indexPressed==1 && this.state.spisakFajlova[f].type=='image')
        najnovijiSpisak3.push(this.state.spisakFajlova[f]);
    }        
      
    return (      
      <View style={styles.container}>
        <View style={styles.navBar}>
          {komponentaNaslov}
        </View>
        <View style={styles.body}>
          <ScrollView>
            <FlatList
              data={najnovijiSpisak1}
              renderItem={({ item }) => <this.Item title={item.name} type={item.type} />}
              keyExtractor={item => item.name}
              ItemSeparatorComponent={()=><View style={{height:1,backgroundColor:'#E5E5E5'}}/>}
            /> 
            <View style={{height:1,backgroundColor:'#E5E5E5'}}/>
            <FlatList
              data={najnovijiSpisak2}
              renderItem={({ item }) => <this.Item title={item.name} type={item.type} />}
              keyExtractor={item => item.name}
              ItemSeparatorComponent={()=><View style={{height:1,backgroundColor:'#E5E5E5'}}/>}
            /> 
            <View style={{height:1,backgroundColor:'#E5E5E5'}}/>
            <FlatList
              data={najnovijiSpisak3}
              renderItem={({ item }) => <this.Item title={item.name} type={item.type} />}
              keyExtractor={item => item.name}
              ItemSeparatorComponent={()=><View style={{height:1,backgroundColor:'#E5E5E5'}}/>}
            />              
          </ScrollView>
        </View>      
        <View style={styles.tabBar}>
          <TouchableWithoutFeedback style={{flex:1}} onPress={()=>this._onPressButtonBottom(0)} background={TouchableNativeFeedback.SelectableBackground()}>
            <View>
              <Icon style={bottomFirstStyleIcon} name="video" size={25}/>
              <Text style={bottomFirstStyle}>Videos</Text>
            </View>
          </TouchableWithoutFeedback>
          <TouchableWithoutFeedback style={{flex:1}} onPress={()=>this._onPressButtonBottom(1)} background={TouchableNativeFeedback.SelectableBackground()}>
            <View>
              <Icon style={bottomSecondStyleIcon} name="image" size={25} />
              <Text style={bottomSecondStyle}>Images</Text>
            </View>
          </TouchableWithoutFeedback>
        </View>
      </View>
    );        
  }
}

const styles = StyleSheet.create({
    container: {
      flex: 1
    },
    navBar: {
      height:55,
      backgroundColor:'#F44336',
      elevation: 3,
      paddingHorizontal: 15,
      flexDirection: 'row',
      alignItems: 'center',
      justifyContent: 'space-between'
    },
    body: {
      flex: 1
    },
    tabBar: {
      height:55,
      backgroundColor:'#F44336',
      borderTopWidth: 0.5,
      borderColor: '#E5E5E5',
      flexDirection: 'row',
      justifyContent: 'space-around',
      display:'flex'
    },
    item:
    {
      padding:5,
      height:55.5,
      display:'flex',
      flexDirection:'row'  
    },
    title:{
      color:'black',
      marginTop:10,
      fontSize:16
    },
    fileTypeIcon:{
      color:'grey',
      width:50
    },
    whiteStyle:{
      color:'white'
    },
    greyStyle:{
      color:'#444444'
    },
    whiteStyleIcon:{
        color:'white',
        marginLeft:10 
    },
    greyStyleIcon:{
        color:'#444444',
        marginLeft:10
    },
    bottomTopIcon:{
      color:'white'
    }
  });

export default FileExplorer
