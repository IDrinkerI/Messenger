import React from "react";
import { Provider } from "react-redux";
import { store } from "../store";


const Application = () => (
    <Provider store={store}>
        <h1> Hallo from react</ h1>
    </Provider>
)

export default Application;