export class MessageModel {
    constructor(id, nickname, text, profileId, chatId) {
        this.id        = id;
        this.nickname  = nickname;
        this.text      = text;
        this.profileId = profileId;
        this.chatId    = chatId
    }
}
