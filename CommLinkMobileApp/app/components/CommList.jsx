import React, { Component } from "react";
import {
  RefreshControl,
  SafeAreaView,
  ScrollView,
  StyleSheet,
  Text,
  View,
} from "react-native";
import { List, Provider as PaperProvider } from "react-native-paper";
import colors from "../config/colors";
export default class CommList extends Component {
  handleListItemPress = (row) => {
    this.props.connection.invoke("NeedCommLastData", row.analyzerID);
    this.props.navigation.navigate("LiveData", {
      row: row,
      connection: this.props.connection,
    });
  };

  constructor(props) {
    super(props);
    this.state = {
      data: [],
      refreshing: true,
    };
  }
  /*
  loadData = () => {
    this.props.connection.on("ReceiveAllActiveComs", (o) => {
      console.log(o);
      this.setState({ data: JSON.parse(o) });
    });
  };

  onRefresh = React.useCallback(() => {
    this.state.refreshing = true;
    this.loadData();
    this.state.refreshing = false;
  }, []);
*/
  onRefresh = () => {
    this.state.refreshing = true;
    this.props.connection.invoke("NeedAllActiveComms");
  };

  componentDidMount = () => {
    this.props.connection.on("ReceiveAllActiveComms", (o) => {
      this.props.updateHaveComms(true);
      //console.log(o);
      this.state.refreshing = false;
      this.setState({ data: JSON.parse(o) });
    });
  };
  render() {
    return (
      <View style={styles.container}>
        <ScrollView
          refreshControl={
            <RefreshControl
              refreshing={this.state.refreshing}
              onRefresh={this.onRefresh}
            />
          }
        >
          <List.Section
            style={styles.listSection}
            title="Active communications"
            titleStyle={{ color: colors.white }}
          >
            {this.state.data.map((row) => {
              return (
                <List.Item
                  style={styles.listItem}
                  key={row.analyzerID}
                  title={row.analyzerCode + " -> " + row.ISCode}
                  description={
                    row.analyzerProtocolName +
                    " " +
                    row.analyzerTCPIP +
                    ":" +
                    row.analyzerPort +
                    " -> " +
                    row.ISProtocolName +
                    " " +
                    row.ISTCPIP +
                    ":" +
                    row.ISPort
                  }
                  onPress={() => this.handleListItemPress(row)}
                />
              );
            })}
          </List.Section>
        </ScrollView>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    width: "100%",
  },
  listItem: {
    backgroundColor: colors.Third,
    width: "100%",
    height: 70,
  },
  listSection: {
    backgroundColor: colors.secondary,
    textDecorationColor: colors.white,
  },
});

/*
{this.state.data.map((row)=>{
    return(
    <ListItemButton key={row.analyzerID}>
        <ListItemText primary = {row.analyzerCode}>
            <ListItemIcon>
                <DeviceHubIcon/>
            </ListItemIcon>
        </ListItemText>
    </ListItemButton>);

   {this.state.data.map((row) => {
          return <List.Item key={row.analyzerID} title={row.analyzercode} />;
        })}

})}*/
