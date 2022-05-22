//import { StatusBar } from "expo-status-bar";
import {
  StyleSheet,
  Text,
  View,
  SafeAreaView,
  Image,
  TouchableHighlight,
  Button,
  Alert,
  Platform,
  StatusBar,
  Dimensions,
} from "react-native";
import {
  useDimensions,
  useDeviceOrientation,
} from "@react-native-community/hooks";

export default function App() {
  console.log(Dimensions.get("screen")); // To detect dimensions of the screen or window
  const { landscape } = useDeviceOrientation();
  let x = 1;
  console.log("Executed");

  const handlePress = () => console.log("Text pressed");

  console.log(require("./assets/splash.png"));

  //ctrl + space to look for values in properties
  return (
    <View
      style={{
        backgroundColor: "#fff",
        flex: 1,
        flexDirection: "row", //horizontal
        justifyContent: "center", //main axis
        alignItems: "center", //secondary axis alignment each line
        alignContent: "center", //alignmen of entire content of a view container
        flexWrap: "wrap",
      }}
    >
      <View
        style={{
          backgroundColor: "blue",
          //width: 100,
          height: 100,
          flexBasis: 100, // flexBasis  width or height? along primary axis!
          flexGrow: 1, //flex same with flewGrowth?
          flexShrink: 1, //if overflowing shrink that other elemts would fit.
          //alignSelf: "flex-start",
        }}
      />
      <View
        style={{
          backgroundColor: "gold",
          width: 100,
          height: 100,
          position: "relative", // absolute accordint his parent, relative normal positioning.
        }}
      />
      <View
        style={{
          backgroundColor: "tomato",
          width: 100,
          height: 100,
        }}
      />
      <View
        style={{
          backgroundColor: "grey",
          width: 100,
          height: 100,
        }}
      />
      <View
        style={{
          backgroundColor: "green",
          width: 100,
          height: 100,
        }}
      />
    </View>
  );

  /*
  return (
    <SafeAreaView style={styles.container}>
      <View
        style={{
          backgroundColor: "dodgerblue",
          width: "100%",
          height: landscape ? "100%" : "30%",
        }}
      ></View>
    </SafeAreaView>
  );
*/
  /*
  return (
    <SafeAreaView style={styles.container}>
      <Text numberOfLines={1} onPress={handlePress}>
        Hello world!
      </Text>
      {/* 
      <Image source={require("./assets/splash.png")} />
       
      <TouchableHighlight onPress={() => console.log("Image tapped.")}>
        <Image
          //blurRadius={0}
          //fadeDuration={1000}
          source={{
            width: 200,
            height: 300,
            uri: "https://picsum.photos/200/300",
          }}
        />
      </TouchableHighlight>
      <Button
        color={"orange"}
        title="Click me"
        onPress={() =>
          Alert.alert("Title", "Message", [
            { text: "Yes", onPress: () => console.log("Yes") },
            { text: "No", onPress: () => console.log("No") },
          ])
        }
      />
      <StatusBar style="auto" />
    </SafeAreaView>
  );
  */
}

const containerStyle = { backgroundColor: "Orange" };

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    //width: "100%",
    //height: "30%",
    //alignItems: "center",
    //justifyContent: "center",
    paddingTop: Platform.OS === "android" ? StatusBar.currentHeight : 0,
  },
});

//orientation in app.json to change to default orientation of the phone
// use hooks
