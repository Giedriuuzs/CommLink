import React, { Component } from "react";
import { StyleSheet, View, ScrollView, RefreshControl } from "react-native";
import { List, Provider as PaperProvider, Switch } from "react-native-paper";
import colors from "../config/colors";
export default class CommLiveData extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      refreshing: true,
      isSwitchOn: false,
    };
  }

  onToggleSwitch = () => {
    this.setState({ isSwitchOn: !this.state.isSwitchOn });
    this.turnOnOffCommunication();
  };

  turnOnOffCommunication = () => {
    this.props.connection.invoke(
      "turnOnOffCommunication",
      this.props.row.analyzerID,
      !this.state.isSwitchOn
    );
  };
  //scrollViewRef = React.useRef();

  componentDidMount = () => {
    this.setState({ isSwitchOn: this.props.row.active });
    this.props.connection.on("ReceiveCommLastData", (o) => {
      //console.log(o);
      this.setState({ data: JSON.parse(o) });
    });
    this.props.connection.on("newData", (str, analyzerID) => {
      // console.log(str + ";  " + analyzerID);
      if (this.props.row.analyzerID == analyzerID) {
        var data2 = this.state.data;
        data2.push(str);
        this.setState({ data: data2 });
      }
      //this.setState({ data: JSON.parse(o) });
    });
    this.props.connection.on("turnOnOffClient", (analyzerID, onOff) => {
      if (this.props.row.analyzerID == analyzerID) {
        this.setState({ isSwitchOn: onOff });
      }
    });
    this.state.refreshing = false;
  };

  render() {
    return (
      <View style={styles.container}>
        <View style={styles.upperContainer}>
          <List.Section
            style={styles.listSection}
            title={this.props.row.analyzerCode}
            titleStyle={{ color: colors.white }}
            children={null}
          ></List.Section>
          <Switch
            value={this.state.isSwitchOn}
            onValueChange={this.onToggleSwitch}
            style={styles.switch}
          />
        </View>
        <ScrollView
          /*
            ref={this.scrollViewRef}
            onContentSizeChange={() => {
              this.scrollViewRef.current.scrollToEnd({ animated: true });
            }}*/
          refreshControl={
            <RefreshControl
              refreshing={this.state.refreshing}
              //onRefresh={this.onRefresh}
            />
          }
        >
          {this.state.data.map((row, i) => {
            return (
              <List.Item
                key={i}
                style={styles.listItem}
                title={row}
                titleNumberOfLines={5}
              ></List.Item>
            );
          })}
          {}
        </ScrollView>
      </View>
    );
  }
}

const styles = StyleSheet.create({
  upperContainer: {
    width: "100%",
    backgroundColor: colors.secondary,
    flexDirection: "row",
  },
  container: {
    flex: 1,
    width: "100%",
    backgroundColor: colors.primary,
  },
  listItem: {
    backgroundColor: colors.Third,
    width: "100%",
    flexShrink: 1,
    borderColor: colors.black,
    borderStyle: "solid",
    borderWidth: 0.5,
  },
  listSection: {
    height: "80%",
    backgroundColor: colors.secondary,
    flex: 5,
  },
  switch: {
    backgroundColor: colors.secondary,
    flex: 1,
    height: "100%",
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
