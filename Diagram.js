const classRegex = /class\s+(\w+)/;

function findLinesWithSameLeadingSpaces(lines) {
  const groupedLines = {};

  let currentSpace = 0;
  let currentClass = "";
  let defaultClass = classRegex.exec(lines[0])[1];
  let isClassChanged = false;

  for (const line of lines) {
    const leadingSpaces = line.match(/^\s*/)[0].length;
    if (isClassChanged) {
      currentSpace = leadingSpaces;
      isClassChanged = false;
    }
    if (leadingSpaces < currentSpace) {
      currentClass = defaultClass;
    }

    if (line.includes(" class ")) {
      const className = classRegex.exec(line)[1];
      groupedLines[className] = [];
      currentClass = className;
      isClassChanged = true;
      continue;
    }

    if (line.includes("(")) {
      pushToClass(groupedLines[currentClass], extractFunction(line));
      continue;
    }

    if (line.includes("{")) {
      pushToClass(groupedLines[currentClass], extractGetter(line));
      continue;
    }

    pushToClass(groupedLines[currentClass], extractNormal(line));
  }
  return groupedLines;
}

function pushToClass(groupedLines, value) {
  if (
    !groupedLines.filter((item) => item.toLowerCase() == value.toLowerCase())[0]
  ) {
    groupedLines.push(value);
  }
}

function extractNormal(line) {
  const normalCut = line.split(" ");
  return normalCut[normalCut.length - 1];
}

function extractGetter(line) {
  const separateBySymbol = line.split("{")[0].split(" ");
  return separateBySymbol[separateBySymbol.length - 2];
}

function extractFunction(line) {
  const separateBySymbol = line.split("(")[0].split(" ");
  return separateBySymbol[separateBySymbol.length - 1] + "()";
}

module.exports = {
  findLinesWithSameLeadingSpaces,
};
