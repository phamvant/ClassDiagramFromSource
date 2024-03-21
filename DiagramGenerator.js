const fs = require("fs");
const path = require("path");
const { DoTheMagic } = require("./DoTheMagic");
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

function main(folderPath, fileList, blackList, folderName) {
  fileList.forEach((fileName, index) => {
    if (blackList.includes(fileName)) {
      return;
    }

    const result = DoTheMagic(path.join(folderPath, fileName));

    try {
      fs.mkdirSync(`./result/${folderName}`, { recursive: true });
      fs.writeFileSync(
        `./result/${folderName}/${fileName.replace(".cs", ".pu")}`,
        JsonToPlantUmlClassDiagram(result)
      );
      console.log("  File written successfully!");
    } catch (error) {
      console.error("Error writing file:", error);
    }
  });
}

const folderNames = ["ViewModels"];
const sourcePath = "WPFTutorial";
const blackList = ["INavigationService.cs"];

folderNames.forEach((folderName) => {
  const folderPath = path.join(sourcePath, folderName);
  const fileList = getListOfFiles(folderPath);
  main(folderPath, fileList, blackList, folderName);
});
