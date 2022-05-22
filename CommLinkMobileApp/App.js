//import { StatusBar } from "expo-status-bar";
//import { NavigationContainer } from "@react-navigation/native";
import {
  StyleSheet,
  View,
  Text,
  ImageBackground,
  Image,
  LogBox,
} from "react-native";
import HomeScreen from "./app/screens/HomeScreen";
import { registerRootComponent } from "expo";
import ImageScreen from "./app/screens/ImageScreen";
import { List, Provider as PaperProvider } from "react-native-paper";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import colors from "./app/config/colors";

LogBox.ignoreAllLogs(true);

export default function App() {
  const Stack = createNativeStackNavigator();
  //ctrl + space to look for values in properties
  return (
    <PaperProvider>
      <NavigationContainer>
        <Stack.Navigator>
          <Stack.Screen
            name="Home"
            component={HomeScreen}
            options={{ title: "CommLink" }}
          />
          <Stack.Screen name="LiveData" component={ImageScreen} />
        </Stack.Navigator>
      </NavigationContainer>
    </PaperProvider>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: colors.primary,
    //alignItems: "center",
    //justifyContent: "center",
    //width: "100%",
    //height: "30%",
    //alignItems: "center",
    //justifyContent: "center",
    //paddingTop: Platform.OS === "android" ? StatusBar.currentHeight : 0,
  },
});

//registerRootComponent(App);
