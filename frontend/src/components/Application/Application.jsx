import React from "react";
import { Provider } from "react-redux";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { store } from "../../store";
import { Messenger } from "../Messenger";
import { Profile } from "../Profile";


export const Application = () => (
    <Provider store={store}>
        <BrowserRouter>
            <Switch>
                <Route exact path="/">
                    <Messenger />
                </Route>

                <Route path="/profile">
                    <Profile />
                </Route>
            </Switch>
        </BrowserRouter>
    </Provider>
)
