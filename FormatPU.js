const jsonToPlantUml = require("json-to-plantuml");

async function FormatPU(data) {
  const formatData = await jsonToPlantUml(data);
  let lines = formatData.split(/\r?\n/);
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
    if (lines[index].includes("&lt;")) {
      lines[index] = lines[index].replace(`&lt;`, "<").replace(`&gt;`, ">");
    }
  });

  return lines.join("\n");
}

module.exports = {
  FormatPU,
};
