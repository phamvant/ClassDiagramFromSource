const fs = require("fs");
const Diagram = require("./Diagram");

function readFileLineByLine(filePath) {
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
      Diagram.findLinesWithSameLeadingSpaces(filterOverTab);
    }
  });
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

fileList.forEach((filePath) => {
  readFileLineByLine(folderPath + "\\" + filePath);
});
