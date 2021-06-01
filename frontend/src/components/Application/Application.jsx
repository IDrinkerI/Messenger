import React from "react";
import { Provider } from "react-redux";
import { BrowserRouter, Redirect, Route, Switch } from "react-router-dom";
import { store } from "../../store";
import { Messenger } from "../Messenger";
import { Navigator } from "../Navigator";
import { Profile } from "../Profile";
import { Singin } from "../Signin";
import { Signup } from "../Signup";


export const Application = () => (
    <Provider store={store}>
        <BrowserRouter>
            <Navigator />
            <Switch>
                <Route exact path="/">
                    <Messenger />
                </Route>

                <Route exact path="/profile">
                    <Profile />
                </Route>

                <Route exact path="/singin">
                    <Singin />
                </Route>

                <Route exact path="/signup">
                    <Signup />
                </Route>

                <Redirect to="/" />
            </Switch>
        </BrowserRouter>
    </Provider>
)
