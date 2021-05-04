import React from "react";
import { Provider } from "react-redux";
import { store } from "../store";
import Messenger from "./Messenger.jsx";


const Application = () => (
    <Provider store={store}>
        <Messenger />
    </Provider>
)

export default Application;