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

function Exec(folderPath, fileList, blackList, folderName) {
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

function DiagramGenerator(folderNames, sourcePath, blackList) {
  folderNames.forEach((folderName) => {
    const folderPath = path.join(sourcePath, folderName);
    const fileList = getListOfFiles(folderPath);
    Exec(folderPath, fileList, blackList, folderName);
  });
}

// const folderNames = ["ViewModels", "Services"];
// const sourcePath = "sample";
// const blackList = ["INavigationService.cs"];
// DiagramGenerator(folderNames, sourcePath, blackList);

module.exports = DiagramGenerator;
