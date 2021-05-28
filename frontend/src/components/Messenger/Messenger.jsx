import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { MessageModel } from "../../model/MessageModel";
import { updateInputMessageAction } from "../../store/input_message/actions";
import { inputMessageSelector } from "../../store/input_message/selectors";
import { addMessageAction } from "../../store/message/actions";
import { Button } from "../Button";
import { ChatList } from "../ChatList";
import { InputField } from "../InputField";
import { MessageField } from "../MessageField";
import "./messenger.scss";


export const Messenger = () => {
    const dispatch = useDispatch();
    const inputMessage = useSelector(inputMessageSelector);
    const buttonHandler = () => {
        dispatch(addMessageAction(new MessageModel("bot", inputMessage)));
        dispatch(updateInputMessageAction(""));
    }

    return (
        <div className="messenger">
            <div className="messenger_inner">
                <ChatList />
                <MessageField />
            </div>

            <div className="messenger_inner">
                <InputField />
                <Button onClick={buttonHandler}>Send</Button>
            </div>
        </div>
    );
}
