const jsonToPlantUml = require("json-to-plantuml");

async function JsonToPlantUmlClassDiagram(jsonData) {
  return await jsonToPlantUml(jsonData);
}

module.exports = {
  JsonToPlantUmlClassDiagram,
};
