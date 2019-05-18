`timescale 1ns / 1ps
//////////////////////////////////////////////////////////////////////////////////
// Company: 
// Engineer: 
// 
// Create Date: 05/18/2019 10:05:13 AM
// Design Name: 
// Module Name: fifo
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


module fifo
#(parameter B = 8, // Number of bits in a word
            W = 4
  )
            
( 
  input wire clk, reset,
  input wire rd, wr,
  input wire [B-1: 0] w_data,
   output wire empty , full,
   output wire [W - 1 : 0] r_data
    );
    //Signal declaration
    reg [B-1: 0] array_reg [2**W-1:0];  //register array
    reg [W-1:0] w_ptr_reg, w_ptr_next, w_ptr_succ;
    reg [W-1: 0] r_ptr_reg, r_ptr_next, r_ptr_succ;
    reg full_reg, empty_reg, full_next, empty_next;
    wire wr_en;
    
    //body
    //register file write operation
    always@(posedge clk)
    if(wr_en)
    array_reg[w_ptr_reg ] <= w_data;
    
    // register file read operation
    assign r_data = array_reg [r_ptr_reg];
    // write enable only when fifo is not full
    assign wr_en = wr & ~full_reg;
    
    //fifo control
    //register for read and write pointers
    always@(posedge clk, posedge reset)
    if (reset)
    begin
    w_ptr_reg <= 0;
    r_ptr_reg <= 0;
    full_reg <= 1'b0;
    empty_reg <= 1'b1;
    end
    
    else 
    begin
    w_ptr_reg <= w_ptr_next;
    r_ptr_reg <= r_ptr_next;
    full_reg <= full_next;
    empty_reg <= empty_next;
    end
    
    //next state logic for read and write pointers
    always@*
    begin
    //succes pointer values
    w_ptr_succ = w_ptr_reg + 1;
    r_ptr_succ = r_ptr_reg + 1;
    // default keep values
    
    w_ptr_next = w_ptr_reg;
    r_ptr_next = r_ptr_reg;
    full_next = full_reg;
    empty_next = empty_reg;
    
    case({wr, rd})
    //2'b00 no operation
    2'b01: //read
    if(~empty_reg) // not empty
    begin
    r_ptr_next = r_ptr_succ;
    full_next = 1'b0;
    if (r_ptr_succ == w_ptr_reg)
    empty_next = 1'b1;
    end
    2'b10: //write
    if (~full_reg) //not full
    begin
    w_ptr_next = w_ptr_succ;
    empty_next = 1'b0;
    if(w_ptr_reg == r_ptr_reg)
    full_next = 1'b1;
    end
    2'b11: //Read and write
    begin 
    w_ptr_next = w_ptr_succ;
    r_ptr_next = r_ptr_succ;
    end
    endcase
    end
    
    // output
    assign full = full_reg;
    assign empty = empty_reg;
  
endmodule