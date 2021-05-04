import React from "react";
import MessageModel from "../model/MessageModel.js";
import Message from "./Message.jsx";
import "../style/message_field.scss";


const MessageField = () => (
    <div className="message_field">
        {_messageList.map((item, index) =>
            <Message message={item} key={index} />
        )}
    </div>
);

export default MessageField;


const _messageList = [
    new MessageModel("bot", "hallo"),
    new MessageModel("bot", "Message 1"),
    new MessageModel("bot", "Message 2"),
    new MessageModel("bot", "Message 3"),
];