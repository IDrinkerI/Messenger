import { createStore, applyMiddleware, combineReducers, compose, } from "redux";
import thunk from "redux-thunk";
import { chatsReducer } from "../components/ChatList";
import { inputMessageReducer } from "../components/InputMessage";
import { messageReduser } from "../components/MessageField";
import { profileReducer } from "../components/Profile";


const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export const store = createStore(
    combineReducers({
        messages: messageReduser,
        inputText: inputMessageReducer,
        chats: chatsReducer,
        profile: profileReducer,
    }),
    composeEnhancers(applyMiddleware(thunk))
);
