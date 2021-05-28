import React from "react";
import { Provider } from "react-redux";
import { store } from "../../store";
import { HtmlContainer } from "../HtmlContainer";
import { Messenger } from "../Messenger";


export const Application = () => (
    <Provider store={store}>
        <HtmlContainer>
            <Messenger />
        </HtmlContainer>
    </Provider>
)
