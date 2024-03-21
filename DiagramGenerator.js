const fs = require("fs");
const Diagram = require("./Diagram");
const path = require("path");

function readFileLineByLine(filePath) {
  let result = "";
  fs.readFile(filePath, "utf8", (err, data) => {
    if (err) {
      console.error("Error reading file:", err);
      return;
    }
    const lines = data.split(/\r?\n/);
    const filtered = lines.filter(
      (line) =>
        (line.includes("public") ||
          line.includes("private") ||
          line.includes("internal")) &&
        !line.includes(" _")
    );

    const filterOverTab = filtered.map((line) => {
      return line.replace(/\t/g, " ");
    });

    if (filterOverTab[0]) {
      result = Diagram.findLinesWithSameLeadingSpaces(filterOverTab);
    }
    console.log(result);
  });
  return result;
}

function getListOfFiles(folderPath) {
  try {
    const files = fs.readdirSync(folderPath);
    return files;
  } catch (error) {
    console.error("Error reading directory:", error);
    return [];
  }
}

const folderPath =
  "C:\\Users\\morson\\My\\Remote\\autotune_app\\AutoTune\\AutoTune.Core\\Models";
const fileList = getListOfFiles(folderPath);

const blackList = ["Constant.cs"];

fileList.forEach((fileName, index) => {
  if (blackList.includes(fileName)) {
    return;
  }

  const result = readFileLineByLine(path.join(folderPath, fileName));

  console.log(result);

  // try {
  //   fs.writeFileSync(`.\\${fileName}`, result);
  //   console.log("  File written successfully!");
  // } catch (error) {
  //   console.error("Error writing file:", error);
  // }
});
