import React from "react";
import MessageModel from "../model/MessageModel.js";
import Message from "./Message.jsx";
import "../style/message_field.scss";
import { useDispatch, useSelector } from "react-redux";
import { getMessages } from "../store/message/selectors.js";


const MessageField = () => {
    const dispatch = useDispatch();
    const messageList = useSelector(getMessages);

    return (
        <div className="message_field">
            {messageList?.map((item, index) =>
                <Message message={item} key={index} />
            )}
        </div>
    );
}

export default MessageField;