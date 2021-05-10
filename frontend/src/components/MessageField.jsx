import React from "react";
import Message from "./Message.jsx";
import "../style/message_field.scss";
import { useDispatch, useSelector } from "react-redux";
import { getMessages } from "../store/message/selectors.js";
import { useEffect } from "react";
import { addMessageAction, initMessageStoreAction } from "../store/message/actions.js";
import MessageModel from "../model/MessageModel.js";


const MessageField = () => {
    const dispatch = useDispatch();
    const messageList = useSelector(getMessages);

    //TODO: Use env variable
    if (process.env.NODE_ENV != "development")
        useEffect(() => dispatch(initMessageStoreAction()), []);
    else {
        useEffect(() => {
            dispatch(addMessageAction(new MessageModel("TestBot", "Hallo!")));
            dispatch(addMessageAction(new MessageModel("TestBot", "Some message")));
            dispatch(addMessageAction(new MessageModel("TestBot", "Some message")));
            dispatch(addMessageAction(new MessageModel("TestBot", "Some message")));
        }, [])
    }

    return (
        <div className="message_field">
            {messageList?.map((item, index) =>
                <Message message={item} key={index} />
            )}
        </div>
    );
}

export default MessageField;