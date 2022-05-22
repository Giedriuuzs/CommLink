import { useEffect } from "react";
import { StyleSheet, View, ToastAndroid } from "react-native";
import CommList from "../components/CommList";
import { List, Provider as PaperProvider } from "react-native-paper";
import colors from "../config/colors";

const signalr = require("@microsoft/signalr");
let i = 0;
let j = 0;
let haveComms = false;
let initial = true;
let connection = new signalr.HubConnectionBuilder()
  .withUrl("https://03bd-87-247-108-4.eu.ngrok.io/ClientHub")
  //.configureLogging(signalr.LogLevel.Information)
  .withAutomaticReconnect()
  .build();
/*
function connect() {
  connection.start().then(() => {
    needAllActiveComms();
    console.log("Client send: Need all active comms!");
  });
}
*/
function updateHaveComms(bool) {
  haveComms = bool;
}

function needAllActiveComms() {
  if (j == 5) {
    alert(
      "Communications was not received. Please ensure server is connected to SignalR and restart the app."
    );
    return;
  }
  j++;
  if (haveComms) {
    return;
  } else {
    connection.invoke("NeedAllActiveComms");
    setTimeout(() => needAllActiveComms(), 10000);
    if (initial) {
      initial = false;
      return;
    }
    ToastAndroid.show(
      "Communications was not received. Is the server on? Trying again...",
      ToastAndroid.SHORT
    );
  }
}
/*
const interval = setInterval(function () {
  start();
});
*/
async function start() {
  try {
    await connection.start();
    console.assert(connection.state === signalr.HubConnectionState.Connected);
    ToastAndroid.show("SignalR connected.", ToastAndroid.SHORT);
    needAllActiveComms();
  } catch (err) {
    console.assert(
      connection.state === signalr.HubConnectionState.Disconnected
    );

    ToastAndroid.show(
      "Connection was not established. Reconnecting... Try restarting the app.",
      ToastAndroid.SHORT
    );
    setTimeout(() => start(), 5000);
  }
}
/*
function start() {
  if (i == 5) {
    alert(
      "Connection with SignalR was not established. Please ensure the middleware is available."
    );
    return;
  }
  i++;
  try {
    connection.start().then(() => {
      j = 0;
      console.assert(connection.state === signalr.HubConnectionState.Connected);
      ToastAndroid.show("SignalR connected.", ToastAndroid.SHORT);
      needAllActiveComms();
    });
  } catch (err) {
    console.assert(
      connection.state === signalr.HubConnectionState.Disconnected
    );
    ToastAndroid.show(
      "Connection with SignalR was not established. Reconnecting...",
      ToastAndroid.SHORT
    );
    setTimeout(() => start(), 5000);
  }
}
*/
connection.on("ReceiveMessage", (user, message) => {
  //console.log("Client received: User: " + user + " Message: " + message);
});

connection.onreconnecting((error) => {
  console.assert(connection.state === signalr.HubConnectionState.Reconnecting);
  ToastAndroid.show(
    "Connection to SignalR was lost. Reconnecting...",
    ToastAndroid.SHORT
  );
});

connection.onreconnected((connectionId) => {
  console.assert(connection.state === signalr.HubConnectionState.Connected);
  ToastAndroid.show(
    "Connection with SignalR was reestablished.",
    ToastAndroid.SHORT
  );
});

connection.onclose((error) => {
  console.assert(connection.state === signalr.HubConnectionState.Disconnected);
  alert(
    "Connection with SignalR was lost. Please ensure the middleware is available."
  );
});

function HomeScreen(props) {
  useEffect(() => {
    i = 0;
    start();
  }, []);

  //ctrl + space to look for values in properties
  return (
    <View style={styles.background}>
      <CommList
        updateHaveComms={updateHaveComms}
        connection={connection}
        navigation={props.navigation}
      ></CommList>
    </View>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
    justifyContent: "flex-start",
    alignItems: "center",
    backgroundColor: colors.primary,
  },
  loginButton: {
    backgroundColor: "blue",
    width: "100%",
    height: 70,
  },
  logo: {},
  logoContainer: {
    position: "absolute",
    top: 25,
    alignItems: "center",
  },
  registerButton: {
    backgroundColor: "gold",
    width: "100%",
    height: 70,
  },
});

export default HomeScreen;

/*
<ImageBackground
      source={{
        uri: "https://picsum.photos/200/300",
      }}
      style={styles.background}
    >
      <View style={styles.logoContainer}>
        <Image
          style={styles.logo}
          source={{
            width: 100,
            height: 150,
            uri: "https://picsum.photos/200/300",
          }}
        />
        <Text>TestText</Text>
      </View>

      <View style={styles.loginButton}></View>
      <View style={styles.registerButton}></View>
      
    </ImageBackground>

    */
