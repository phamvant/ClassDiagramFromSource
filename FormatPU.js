const jsonToPlantUml = require("json-to-plantuml");

async function FormatPU(data) {
  const formatData = await jsonToPlantUml(data);
  const lines = formatData.split(/\r?\n/);
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
