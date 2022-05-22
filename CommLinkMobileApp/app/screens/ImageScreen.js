import React from "react";
import { Button, Image, StyleSheet, View } from "react-native";
import colors from "../config/colors";
import CommLiveData from "../components/CommLiveData";

function ImageScreen(props) {
  return (
    <CommLiveData
      row={props.route.params.row}
      connection={props.route.params.connection}
    />
  );
}

const styles = StyleSheet.create({
  closeIcon: {
    width: 50,
    height: 50,
    backgroundColor: colors.primary,
    position: "absolute",
    top: 50,
    left: 30,
  },
  container: {
    backgroundColor: colors.black,
    flex: 1,
  },
  deleteIcon: {
    width: 50,
    height: 50,
    backgroundColor: colors.secondary,
    position: "absolute",
    top: 50,
    right: 30,
  },
  image: {
    width: "100%",
    height: "100%",
  },
});

/*
<View style={styles.container}>
<View style={styles.closeIcon}></View>
<View style={styles.deleteIcon}></View>
<Image
  resizeMode="contain"
  style={styles.image}
  source={{
    width: 100,
    height: 150,
    uri: "https://picsum.photos/200/300",
  }}
/>
</View>
*/

export default ImageScreen;
