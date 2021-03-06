using MultyLayerPerceptron.CalculatingGraph.GraphParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultyLayerPerceptron.CalculatingGraph.Nodes.Concrete
{
    public class MatrixTransposeNode : SingleInputNode
    {
        protected override Batch ComputeForwardResult(Batch leftResult, Batch rightResult)
        {
            return leftResult.ForEachMatrix(x => x.Transposed());
        }

        protected override Batch ComputeGradientByLeft(Batch inputGradientResult, Batch leftResult, Batch rightResult)
        {
            return inputGradientResult;
        }
    }
}
