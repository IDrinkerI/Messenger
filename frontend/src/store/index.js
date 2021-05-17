import { createStore, applyMiddleware, combineReducers, compose, } from "redux";
import thunk from "redux-thunk";
import { chatsReducer } from "./chats/reducer";
import { inputMessageReducer } from "./input_message/reducer";
import { messageReduser } from "./message/reducer";


const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export const store = createStore(
    combineReducers({
        message: messageReduser,
        inputText: inputMessageReducer,
        chats: chatsReducer,
    }),
    composeEnhancers(applyMiddleware(thunk))
)