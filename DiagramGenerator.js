const fs = require("fs");
const { DoTheMagic } = require("./Diagram");
const path = require("path");
const { JsonToPlantUmlClassDiagram } = require("./ToPlantUML");

//----------------------EXEC----------------------//

function getListOfFiles(folderPath) {
  try {
    const files = fs.readdirSync(folderPath);
    return files;
  } catch (error) {
    console.error("Error reading directory:", error);
    return [];
  }
}

function main(folderPath, fileList, blackList) {
  fileList.forEach((fileName, index) => {
    if (blackList.includes(fileName)) {
      return;
    }

    const result = DoTheMagic(path.join(folderPath, fileName));

    try {
      fs.writeFileSync(
        `./result/${fileName.replace(".cs", ".pu")}`,
        JsonToPlantUmlClassDiagram(result)
      );
      console.log("  File written successfully!");
    } catch (error) {
      console.error("Error writing file:", error);
    }
  });
}

const folderPath = "./WPFTutorial/ViewModels";
const fileList = getListOfFiles(folderPath);
const blackList = ["INavigationService.cs"];

main(folderPath, fileList, blackList);
