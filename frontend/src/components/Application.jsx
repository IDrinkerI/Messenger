import React from "react";
import { Provider } from "react-redux";
import { store } from "../store";
import HtmlContainer from "./HtmlContainer.jsx";
import Messenger from "./Messenger.jsx";


const Application = () => (
    <Provider store={store}>
        <HtmlContainer>
            <Messenger />
        </HtmlContainer>
    </Provider>
)

export default Application;