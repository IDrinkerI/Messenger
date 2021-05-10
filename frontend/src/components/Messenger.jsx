import React from "react";
import "../style/messenger.scss";
import Button from "./Button.jsx";
import ChatList from "./ChatList.jsx";
import InputField from "./InputField.jsx";
import MessageField from "./MessageField.jsx";


const Messenger = () => (
    <div className="messenger">
        <div className="messenger_inner">
            <ChatList />
            <MessageField />
        </div>

        <div className="messenger_inner">
            <InputField />
            <Button>Send</Button>
        </div>
    </div>
);

export default Messenger;