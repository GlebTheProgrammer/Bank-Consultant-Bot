using OtoBot;

var dialogflow = new DialogflowManager();

var dialogflowQueryResult = await dialogflow.CheckIntent("Привет");