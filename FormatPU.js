const fs = require("fs");
const path = require("path");

function FormatPU(data) {
  const lines = data.split(/\r?\n/);
  lines.forEach((line, index) => {
    if (line.includes("+")) {
      lines[index] = "+" + " " + line.split("+")[1];
    }
    if (line.includes("-")) {
      lines[index] = "-" + " " + line.split("-")[1];
    }
    if (line.includes("..")) {
      lines[index] = "";
    }
  });

  return lines.join("\n");
}

module.exports = {
  FormatPU,
};
