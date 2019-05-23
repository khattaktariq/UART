`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 05/17/2019 11:29:49 AM
// Design Name: 
// Module Name: COUNTER_FOR_BAUD
// Project Name: 
// Target Devices: 
// Tool Versions: 
// Description: 
// 
// Dependencies: 
// 
// Revision:
// Revision 0.01 - File Created
// Additional Comments:
// 
//////////////////////////////////////////////////////////////////////////////////


module COUNTER_FOR_BAUD
#(
parameter N = 9, M = 326
)
(
input wire clk, reset,
output wire max_tick,
output wire [N-1 : 0] q
 );
 // signal declaration
 reg [N-1 : 0] r_reg;
 wire [N-1 : 0] r_next;
 
 //body
 //register
 always @(posedge clk , posedge reset)
 if (reset)
 r_reg <= 0;
 else 
 r_reg <= r_next;
 
 //next state logic
 assign r_next = (r_reg ==(M-1))? 0 : r_reg + 1;
 //output logic
 assign q = r_reg;
 assign max_tick = (r_reg ==(M-1)) ? 1'b1: 1'b0 ;
 
endmodule
