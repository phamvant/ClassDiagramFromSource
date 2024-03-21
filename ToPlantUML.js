function JsonToPlantUmlClassDiagram(jsonData) {
  if (typeof jsonData !== "object" || jsonData === null) {
    throw new Error("Invalid input: Data must be a JSON object.");
  }

  const className = Object.keys(jsonData)[0];

  let plantUml = `class ${className} {\n`;

  for (const propertyMethod of jsonData[className]) {
    const parts = propertyMethod.split(/(\+|-|~)/);
    const visibility = parts[1] || "+"; // Default to public visibility
    const nameReturnType = parts[2];

    plantUml += `  ${visibility} ${nameReturnType}\n`;
  }

  plantUml += "}";

  return plantUml;
}

module.exports = {
  JsonToPlantUmlClassDiagram,
};
